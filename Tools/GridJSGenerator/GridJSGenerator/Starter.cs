using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace GridJSGenerator
{
    public partial class Starter : Form
    {
        private DialogResult _result;
        private List<string> _selectedColumns = new List<string>();
        private List<ColumnOrdering> _columnOrderings = new List<ColumnOrdering>();
        public DataSet PropertyValues;
        private string _jsTemplate = string.Empty;
        private string _cshtmlTemplate = string.Empty;

        private const string DeleteColumnTemplate = @" {
            field: 'Delete',
            attributes: { 'class': 'first-cell', sg_Customizable: false },
            headerAttributes: { 'class': 'first-cell' },
            template: sg.controls.ApplyCheckboxStyle(""<input type='checkbox' class='selectChk' />""),
            headerTemplate: sg.controls.ApplyCheckboxStyle(""<input type='checkbox' id='selectAllChk' />""),
            reorderable: false,
            editor: function (e) {
                
            }
        }";
        private const string ColumnTemplate = @"{
            field: '%%ColumnName%%',
            hidden: %%Namespace%%Header.%%ColumnName%%Hidden,
            title: %%Namespace%%Header.%%ColumnName%%Title,
            attributes: { 'class': 'w140  ' },
            headerAttributes: { 'class': 'w140 ' },
            editor: function (container, options) {
               
            }
        }";

        private const string HtmlTemplate = @"
        header%%ColumnName%%: '@Html.SageGridHeaderFor(model => model.%%ColumnName%%)'
        ";

        private const string CustomizationTemplate = @"
        %%ColumnName%%Title: $(%%Namespace%%Header.header%%ColumnName%%).text(),
        %%ColumnName%%Hidden: $(%%Namespace%%Header.header%%ColumnName%%).attr('hidden') ? $(%%Namespace%%Header.headerLineNumber).attr('hidden') : false,";


        public Starter()
        {
            InitializeComponent();
        }

        #region Events
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            _result = openModelAssembly.ShowDialog();
            if (_result == DialogResult.OK)
            {
                txtModelPath.Text = openModelAssembly.FileName;
            }

        }
        private void btnToColumns_Click(object sender, EventArgs e)
        {
            string location = txtModelPath.Text;
            try
            {
                LoadDataSet(location);
                tabCreate.SelectedIndex = tabCreate.SelectedIndex + 1;
                tabCreate.Size = new Size(529, 427);
                Size = new Size(580, 507);
                LoadPropertyGrid();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(@"File not found. Select the right folder");

            }
            catch (NullReferenceException)
            {
                MessageBox.Show(@"The model specified is not found");
            }
        }
        private void btnToOrder_Click(object sender, EventArgs e)
        {
            LoadSelectedProperties();
            tabCreate.SelectedIndex = tabCreate.SelectedIndex + 1;
        }
        private void btnToVariables_Click(object sender, EventArgs e)
        {
            GetTransformedBaseJs();
            GetTransformedBaseCshtml();
            _selectedColumns = _columnOrderings.OrderBy(x => x.ColumnOrder).Select(x => x.Value).ToList();
            if (_selectedColumns.Count <= 4)
            {
                chkUserPref.Checked = false;
            }
            tabCreate.SelectedIndex = tabCreate.SelectedIndex + 1;
        }
        private void cmbModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUserPrefId.Text = @"sg.utls." + cmbModule.Text + @".UserPreferencesType." + txtGridId.Text;
        }
        private void txtGridId_Leave(object sender, EventArgs e)
        {
            txtNameSpace.Text = Char.ToLowerInvariant(txtGridId.Text[0]) + txtGridId.Text.Substring(1) + @"Config";
        }
        private void chkUserPref_CheckedChanged(object sender, EventArgs e)
        {
            label4.Visible = chkUserPref.Checked;
            txtUserPrefId.Visible = chkUserPref.Checked;
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var jsWithColumns = GenerateJs();
            tabCreate.SelectedIndex = tabCreate.SelectedIndex + 1;
            richTextBox1.Text = string.Empty;
            richTextBox1.Text = jsWithColumns;

            var cshtml = GenerateCshtml();
            richTextBox2.Text = string.Empty;
            richTextBox2.Text = cshtml;
        }


        #endregion

        #region Helper methods
        private string GenerateCshtml()
        {
            var columnList = new List<string>();
            columnList.AddRange(_selectedColumns.Select(selectedColumn => HtmlTemplate.Replace("%%ColumnName%%", selectedColumn)));
            _cshtmlTemplate = _cshtmlTemplate.Replace("%%NameSpace%%", txtNameSpace.Text).Replace("%%Columns%%", string.Join(",", columnList.ToArray()));
            _cshtmlTemplate = _cshtmlTemplate.Replace("%%GridId%%", txtGridId.Text);
            _cshtmlTemplate = _cshtmlTemplate.Replace("%%JSViewModel%%", txtJSViewModel.Text);
            return _cshtmlTemplate;
        }


        private string GenerateJs()
        {
            string jsWithNs = _jsTemplate.Replace("%%NameSpace%%", txtNameSpace.Text);
            string jsWithGrid = jsWithNs.Replace("%%GridId%%", txtGridId.Text);
            string jsWithVm = jsWithGrid.Replace("%%JSViewModel%%", txtJSViewModel.Text);
            string jsWithUrl =
                jsWithVm.Replace("%%Module%%", cmbModule.Text)
                    .Replace("%%Controller%%", txtController.Text)
                    .Replace("%%Action%%", txtAction.Text);
            string jsWithUserPref;
            if (chkUserPref.Checked)
            {
                jsWithUserPref = jsWithUrl.Replace("%%SetUserPreference%%", @"columnReorder: function (e) {
                                    GridPreferencesHelper.saveColumnOrder(e, '#" + txtGridId.Text + @"', '" +
                                                                            txtUserPrefId.Text + @"%%UserPrefId%%');
                                    },");
            }
            else
            {
                jsWithUserPref = jsWithUrl.Replace("%%SetUserPreference%%", string.Empty);
            }

            string jsWithColumns = AddColumns(jsWithUserPref);
            string jsWithCustomization = AddCustomizationColumns(jsWithColumns);
            return jsWithCustomization;
        }

        private string AddCustomizationColumns(string jsWithColumns)
        {
            var columnList = new List<string>();
            jsWithColumns = jsWithColumns.Replace("%%NameSpace%%", txtNameSpace.Text);
            columnList.AddRange(_selectedColumns.Select(selectedColumn => CustomizationTemplate.Replace("%%ColumnName%%", selectedColumn).Replace("%%Namespace%%", txtNameSpace.Text)));
            return jsWithColumns.Replace("%%Customization%%", string.Join(string.Empty, columnList.ToArray()));
        }

        private string AddColumns(string jsWithUserPref)
        {
            var columnList = new List<string>();
            if (chkHasDelete.Checked)
            {
                columnList.Add(DeleteColumnTemplate);
            }
            columnList.AddRange(_selectedColumns.Select(selectedColumn => ColumnTemplate.Replace("%%ColumnName%%", selectedColumn).Replace("%%Namespace%%", txtNameSpace.Text)));
            return jsWithUserPref.Replace("%%Columns%%", string.Join(",", columnList.ToArray()));
        }

        private void LoadSelectedProperties()
        {
            _selectedColumns = new List<string>();

            foreach (DataGridViewRow row in dataGridProperties.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    _selectedColumns.Add(row.Cells[1].Value.ToString());
                }
            }
            _columnOrderings = _selectedColumns.Select((x, ic) => new ColumnOrdering { Value = x, ColumnOrder = ic }).ToList();
            dataSelectedProperties.DataSource = _columnOrderings;
        }

        private void LoadPropertyGrid()
        {
            dataGridProperties.Columns.Clear();
            dataGridProperties.AllowUserToAddRows = true;
            var propertySelection = new DataGridViewCheckBoxColumn { HeaderText = @"Is Grid Column?" };
            dataGridProperties.Columns.Add(propertySelection);
            dataGridProperties.Visible = true;
            dataGridProperties.DataSource = PropertyValues.Tables[0];
            foreach (DataGridViewColumn column in dataGridProperties.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            dataGridProperties.Refresh();
        }

        private void LoadDataSet(string location)
        {
            var assembly = Assembly.LoadFrom(location);
            var type = assembly.GetType(assembly.GetName().Name + "." + txtClassName.Text);
            if (type == null)
            {
                type = assembly.GetType(assembly.GetName().Name + "." + "Process" + "." + txtClassName.Text);
            }
            
            var properties = type.GetProperties();
            PropertyValues = new DataSet("Properties");
            var propertyTable = new DataTable("PropertyNames");
            propertyTable.Columns.Add("Property Name");

            foreach (var propertyInfo in properties)
            {
                propertyTable.Rows.Add(propertyInfo.Name);
            }
            PropertyValues.Tables.Add(propertyTable);
        }

        private void GetTransformedBaseJs()
        {
            var generator = new GridJSGenerationHelper();
            _jsTemplate = generator.TransformText();
        }

        private void GetTransformedBaseCshtml()
        {
            var generator = new GridCSHTMLGenerationHelper();
            _cshtmlTemplate = generator.TransformText();
        }
        #endregion



    }
}
