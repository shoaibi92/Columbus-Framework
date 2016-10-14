// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespsaces

using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sage.CA.SBS.ERP.Sage300.AS.Interfaces.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.AS.Interfaces.Services;
using Sage.CA.SBS.ERP.Sage300.AS.Services;
using Sage.CA.SBS.ERP.Sage300.AS.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Authentication;
using Sage.CA.SBS.ERP.Sage300.Common.Services;
using Sage.CA.SBS.ERP.Sage300.Common.Services.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Security;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Web.Security
{
    /// <summary>
    /// Authentication Manager OnPremise Test class for implementing unit test methods
    /// </summary>
    [TestClass]
    public class AuthenticationManagerOnPremiseTest
    {
        #region Login Tests

        /// <summary>
        /// Test method for Login method
        /// </summary>
        /// <remarks>Evaluate view name to be used for display</remarks>
        [TestMethod]
        public void TestLoginViewName()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();

            // Test login method
            authenticationManager.Login();

            // Assert view name is as expected
            Assert.AreEqual(Common.Web.AreaConstants.Core.OnPremiseLoginView,
                authenticationManager.AuthenticationResult.ViewName);
        }

        /// <summary>
        /// Test method for LoginResult method for required company
        /// </summary>
        /// <remarks>Evaluate tag for a required field</remarks>
        [TestMethod]
        public void TestLoginResultRequiredCompany()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();
            var context = new Context();

            // Assign parameters
            const string sessionId = "123456789";
            const string company = "";
            const string userId = "";
            const string password = "";

            // Test login result method
            authenticationManager.LoginResult(sessionId, company, userId, password, container, context);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.RequiredCredential,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for LoginResult method for required user id
        /// </summary>
        /// <remarks>Evaluate tag for a required field</remarks>
        [TestMethod]
        public void TestLoginResultRequiredUserId()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();
            var context = new Context();

            // Assign parameters
            const string sessionId = "123456789";
            const string company = "SAMLTD";
            const string userId = "";
            const string password = "";

            // Test login result method
            authenticationManager.LoginResult(sessionId, company, userId, password, container, context);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.RequiredCredential,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for LoginResult method for user is disabled
        /// </summary>
        /// <remarks>Evaluate tag for disabled user</remarks>
        [TestMethod]
        public void TestLoginResultDisabledUser()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();
            var context = new Context();

            // Register Mock Authentication Session
            UnityUtil.RegisterType(container, typeof(IAuthenticationSession), typeof(MockDisabledUser));

            // Assign parameters
            const string sessionId = "123456789";
            const string company = "SAMLTD";
            const string userId = "USER";
            const string password = "PWD";

            // Test login result method
            authenticationManager.LoginResult(sessionId, company, userId, password, container, context);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.UserDisabled,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for LoginResult method for password change is required
        /// </summary>
        /// <remarks>Evaluate tag for password change required</remarks>
        [TestMethod]
        public void TestLoginResultPasswordChangeRequired()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();
            var context = new Context();

            // Register Mock Authentication Session
            UnityUtil.RegisterType(container, typeof(IAuthenticationSession), typeof(MockPasswordChangeRequired));

            // Assign parameters
            const string sessionId = "123456789";
            const string company = "SAMLTD";
            const string userId = "USER";
            const string password = "PWD";

            // Test login result method
            authenticationManager.LoginResult(sessionId, company, userId, password, container, context);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.PasswordChangeRequired,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for LoginResult method for user is restricted
        /// </summary>
        /// <remarks>Evaluate tag for restricted user</remarks>
        [TestMethod]
        public void TestLoginResultRestrictedUser()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();
            var context = new Context();

            // Register Mock Authentication Session
            UnityUtil.RegisterType(container, typeof(IAuthenticationSession), typeof(MockRestrictedUser));

            // Assign parameters
            const string sessionId = "123456789";
            const string company = "SAMLTD";
            const string userId = "USER";
            const string password = "PWD";

            // Test login result method
            authenticationManager.LoginResult(sessionId, company, userId, password, container, context);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.UserRestricted,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for LoginResult method for user is locked
        /// </summary>
        /// <remarks>Evaluate tag for locked user</remarks>
        [TestMethod]
        public void TestLoginResultLockedUser()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();
            var context = new Context();

            // Register Mock Authentication Session
            UnityUtil.RegisterType(container, typeof(IAuthenticationSession), typeof(MockLockeddUser));

            // Assign parameters
            const string sessionId = "123456789";
            const string company = "SAMLTD";
            const string userId = "USER";
            const string password = "PWD";

            // Test login result method
            authenticationManager.LoginResult(sessionId, company, userId, password, container, context);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.UserLocked,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for LoginResult method for bad credentials
        /// </summary>
        /// <remarks>Evaluate tag for bad credentials</remarks>
        [TestMethod]
        public void TestLoginResultBadCredentials()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();
            var context = new Context();

            // Register Mock Authentication Session
            UnityUtil.RegisterType(container, typeof(IAuthenticationSession), typeof(MockBadCredentials));

            // Assign parameters
            const string sessionId = "123456789";
            const string company = "SAMLTD";
            const string userId = "USER";
            const string password = "PWD";

            // Test login result method
            authenticationManager.LoginResult(sessionId, company, userId, password, container, context);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.LoginFailure,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for LoginResult method for unknown
        /// </summary>
        /// <remarks>Evaluate tag for unknown</remarks>
        [TestMethod]
        public void TestLoginResultUnknownException()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();
            var context = new Context();

            // Register Mock Authentication Session
            UnityUtil.RegisterType(container, typeof(IAuthenticationSession), typeof(MockUnknownException));

            // Assign parameters
            const string sessionId = "123456789";
            const string company = "SAMLTD";
            const string userId = "USER";
            const string password = "PWD";

            // Test login result method
            authenticationManager.LoginResult(sessionId, company, userId, password, container, context);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.LoginException,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for LoginResult method for password expires today
        /// </summary>
        /// <remarks>Evaluate tag for password expires today</remarks>
        [TestMethod]
        public void TestLoginResultPasswordExpiresToday()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();
            var context = new Context();

            // Register Mock Authentication Session
            UnityUtil.RegisterType(container, typeof(IAuthenticationSession), typeof(MockPasswordExpiresToday));

            // Assign parameters
            const string sessionId = "123456789";
            const string company = "SAMLTD";
            const string userId = "USER";
            const string password = "PWD";

            // Test login result method
            authenticationManager.LoginResult(sessionId, company, userId, password, container, context);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.PasswordExpiresToday,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for LoginResult method for password expires soon
        /// </summary>
        /// <remarks>Evaluate tag for password expires soon</remarks>
        [TestMethod]
        public void TestLoginResultPasswordExpiresSoon()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();
            var context = new Context();

            // Register Mock Authentication Session
            UnityUtil.RegisterType(container, typeof(IAuthenticationSession), typeof(MockPasswordExpiresSoon));

            // Assign parameters
            const string sessionId = "123456789";
            const string company = "SAMLTD";
            const string userId = "USER";
            const string password = "PWD";

            // Test login result method
            authenticationManager.LoginResult(sessionId, company, userId, password, container, context);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.PasswordExpiresSoon,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for LoginResult method for success
        /// </summary>
        /// <remarks>Evaluate IsSuccess for a login success</remarks>
        [TestMethod, Ignore]
        public void TestLoginResultLoginSuccess()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();
            var context = new Context {Container = container};

            // Setup mock objects
            var mockUserTenantResolver = new Mock<IUserTenantResolver>();
            mockUserTenantResolver.Setup(x => x.ResolveUserTenant(It.IsAny<IUnityContainer>(), context, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new UserTenantInfo(){SelectedTenant = new TenantInfo()});

            var mockCommonService = new Mock<ICommonService>();
            mockCommonService.Setup(x => x.GetActiveApplications()).Returns(new List<ActiveApplication>() {new ActiveApplication() {AppId = "GL"}});

            // Register Mocks
            UnityUtil.RegisterType(container, typeof(IAuthenticationSession), typeof(MockLoginSuccess));
            UnityUtil.RegisterType<ILandlordService, LandlordService>(container);
            container.RegisterInstance(mockUserTenantResolver.Object);
            container.RegisterInstance(mockCommonService.Object);
            UnityUtil.RegisterType<ILandlordRepository, MockLandlordRepository>(container);
            UnityUtil.RegisterType<IUserService<User>, UserEntityService<User>>(container);
            UnityUtil.RegisterType<IUserEntity<User>, MockUserRepository<User>>(container,
                UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));

            // Assign parameters
            const string sessionId = "123456789";
            const string company = "SAMLTD";
            const string userId = "USER";
            const string password = "PWD";

            // Test login result method
            authenticationManager.LoginResult(sessionId, company, userId, password, container, context);

            // Assert tag as expected
            Assert.AreEqual(true, authenticationManager.AuthenticationResult.IsSuccess);

            // Assert user tenant resolver only called once
            mockUserTenantResolver.Verify(x => x.ResolveUserTenant(It.IsAny<IUnityContainer>(), context, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
        #endregion

        #region Change Password Tests
        /// <summary>
        /// Test method for ChangePassword method for required user id
        /// </summary>
        /// <remarks>Evaluate tag for a required field</remarks>
        [TestMethod]
        public void TestChangePasswordRequiredUserId()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();

            // Assign parameters
            const string userId = "";
            const string oldPassword = "";
            const string newPassword = "";
            const string confirmPassword = "";

            // Test login result method
            authenticationManager.ChangePassword(userId, oldPassword, newPassword, confirmPassword, container);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.RequiredCredential,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for ChangePassword method for required old password
        /// </summary>
        /// <remarks>Evaluate tag for a required field</remarks>
        [TestMethod]
        public void TestChangePasswordRequiredOldPassword()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();

            // Assign parameters
            const string userId = "ADMIN";
            const string oldPassword = "";
            const string newPassword = "";
            const string confirmPassword = "";

            // Test login result method
            authenticationManager.ChangePassword(userId, oldPassword, newPassword, confirmPassword, container);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.RequiredCredential,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for ChangePassword method for required new password
        /// </summary>
        /// <remarks>Evaluate tag for a required field</remarks>
        [TestMethod]
        public void TestChangePasswordRequiredNewPassword()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();

            // Assign parameters
            const string userId = "ADMIN";
            const string oldPassword = "OldPassword";
            const string newPassword = "";
            const string confirmPassword = "";

            // Test login result method
            authenticationManager.ChangePassword(userId, oldPassword, newPassword, confirmPassword, container);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.RequiredCredential,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for ChangePassword method for required confirm password
        /// </summary>
        /// <remarks>Evaluate tag for a required field</remarks>
        [TestMethod]
        public void TestChangePasswordRequiredConfirmPassword()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();

            // Assign parameters
            const string userId = "ADMIN";
            const string oldPassword = "OldPassword";
            const string newPassword = "NewPassword";
            const string confirmPassword = "";

            // Test login result method
            authenticationManager.ChangePassword(userId, oldPassword, newPassword, confirmPassword, container);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.RequiredCredential,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for ChangePassword method for password mismatch
        /// </summary>
        /// <remarks>Evaluate tag for a match field</remarks>
        [TestMethod]
        public void TestChangePasswordPasswordMismatch()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();

            // Assign parameters
            const string userId = "ADMIN";
            const string oldPassword = "OldPassword";
            const string newPassword = "NewPassword";
            const string confirmPassword = "mismatch";

            // Test login result method
            authenticationManager.ChangePassword(userId, oldPassword, newPassword, confirmPassword, container);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.PasswordChangeValidation,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for ChangePassword method for password same
        /// </summary>
        /// <remarks>Evaluate tag for a match field</remarks>
        [TestMethod]
        public void TestChangePasswordPasswordSame()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();

            // Assign parameters
            const string userId = "ADMIN";
            const string oldPassword = "NewPassword";
            const string newPassword = "NewPassword";
            const string confirmPassword = "NewPassword";

            // Test login result method
            authenticationManager.ChangePassword(userId, oldPassword, newPassword, confirmPassword, container);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.PasswordChangeValidation,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for ChangePassword method for exception
        /// </summary>
        /// <remarks>Evaluate tag for exception</remarks>
        [TestMethod]
        public void TestPasswordChangeException()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();

            // Register Mock Authentication Session
            UnityUtil.RegisterType(container, typeof(IAuthenticationSession), typeof(MockPasswordChangeException));

            // Assign parameters
            const string userId = "ADMIN";
            const string oldPassword = "OldPassword";
            const string newPassword = "NewPassword";
            const string confirmPassword = "NewPassword";

            // Test login result method
            authenticationManager.ChangePassword(userId, oldPassword, newPassword, confirmPassword, container);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.PasswordChangeException,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for ChangePassword method for Minimum Length
        /// </summary>
        /// <remarks>Evaluate tag for validation</remarks>
        [TestMethod]
        public void TestPasswordChangeMinLength()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();

            // Register Mock Authentication Session
            UnityUtil.RegisterType(container, typeof(IAuthenticationSession), typeof(MockPasswordChangeMinLength));

            // Assign parameters
            const string userId = "ADMIN";
            const string oldPassword = "OldPassword";
            const string newPassword = "NewPassword";
            const string confirmPassword = "NewPassword";

            // Test login result method
            authenticationManager.ChangePassword(userId, oldPassword, newPassword, confirmPassword, container);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.PasswordChangeValidation,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for ChangePassword method for Cannot Change Password
        /// </summary>
        /// <remarks>Evaluate tag for cannot change password</remarks>
        [TestMethod]
        public void TestPasswordChangeCannotChange()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();

            // Register Mock Authentication Session
            UnityUtil.RegisterType(container, typeof(IAuthenticationSession), typeof(MockPasswordChangeCannotChange));

            // Assign parameters
            const string userId = "ADMIN";
            const string oldPassword = "OldPassword";
            const string newPassword = "NewPassword";
            const string confirmPassword = "NewPassword";

            // Test login result method
            authenticationManager.ChangePassword(userId, oldPassword, newPassword, confirmPassword, container);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.PasswordChangeRestriction,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for ChangePassword method for Complex Password Required
        /// </summary>
        /// <remarks>Evaluate tag for complex password required</remarks>
        [TestMethod]
        public void TestPasswordChangeComplexRequired()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();

            // Register Mock Authentication Session
            UnityUtil.RegisterType(container, typeof(IAuthenticationSession), typeof(MockPasswordChangeComplexRequired));

            // Assign parameters
            const string userId = "ADMIN";
            const string oldPassword = "OldPassword";
            const string newPassword = "NewPassword";
            const string confirmPassword = "NewPassword";

            // Test login result method
            authenticationManager.ChangePassword(userId, oldPassword, newPassword, confirmPassword, container);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.PasswordChangeComplexRequired,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for ChangePassword method for Same Password
        /// </summary>
        /// <remarks>Evaluate tag for same password</remarks>
        [TestMethod]
        public void TestPasswordChangeSamePassword()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();

            // Register Mock Authentication Session
            UnityUtil.RegisterType(container, typeof(IAuthenticationSession), typeof(MockPasswordChangeSamePassword));

            // Assign parameters
            const string userId = "ADMIN";
            const string oldPassword = "OldPassword";
            const string newPassword = "NewPassword";
            const string confirmPassword = "NewPassword";

            // Test login result method
            authenticationManager.ChangePassword(userId, oldPassword, newPassword, confirmPassword, container);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.PasswordChangeValidation,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for ChangePassword method for Failure
        /// </summary>
        /// <remarks>Evaluate tag for failure</remarks>
        [TestMethod]
        public void TestPasswordChangeFailure()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();

            // Register Mock Authentication Session
            UnityUtil.RegisterType(container, typeof(IAuthenticationSession), typeof(MockPasswordChangeFailure));

            // Assign parameters
            const string userId = "ADMIN";
            const string oldPassword = "OldPassword";
            const string newPassword = "NewPassword";
            const string confirmPassword = "NewPassword";

            // Test login result method
            authenticationManager.ChangePassword(userId, oldPassword, newPassword, confirmPassword, container);

            // Assert tag as expected
            Assert.AreEqual(AuthenticationException.PasswordChangeFailure,
                authenticationManager.AuthenticationResult.Message.Tag);
        }

        /// <summary>
        /// Test method for ChangePassword method for Success
        /// </summary>
        /// <remarks>Evaluate tag for success</remarks>
        [TestMethod]
        public void TestPasswordChangeSuccess()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();
            var container = new SageUnityContainer();

            // Register Mock Authentication Session
            UnityUtil.RegisterType(container, typeof(IAuthenticationSession), typeof(MockPasswordChangeSuccess));

            // Assign parameters
            const string userId = "ADMIN";
            const string oldPassword = "OldPassword";
            const string newPassword = "NewPassword";
            const string confirmPassword = "NewPassword";

            // Test login result method
            authenticationManager.ChangePassword(userId, oldPassword, newPassword, confirmPassword, container);

            // Assert tag as expected
            Assert.AreEqual(true, authenticationManager.AuthenticationResult.PasswordResult.PasswordChanged);
        }

        #endregion

        #region Clear Tests
        /// <summary>
        /// Test method for Clear method
        /// </summary>
        /// <remarks>Evaluate result for success</remarks>
        [TestMethod]
        public void TestClearSuccess()
        {
            // Locals
            var authenticationManager = new AuthenticationManagerOnPremise();

            // Test login result method
            authenticationManager.Clear();

            // Assert tag as expected
            Assert.AreEqual(true, authenticationManager.AuthenticationResult.IsSuccess);
        }
        #endregion
    }
}
