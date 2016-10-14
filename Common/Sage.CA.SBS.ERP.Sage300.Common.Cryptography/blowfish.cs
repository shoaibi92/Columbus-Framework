/* Copyright (c) 1994-2016 Sage Software, Inc.  All rights reserved. */

using System;
using System.Linq;
using System.Text;

namespace Sage.CA.SBS.ERP.Sage300.Common.Cryptography
{
    /// <summary>
    /// The following class is ported from a4w crypto library written in C.
    /// for details on blowfish algorithm, refer to https://www.schneier.com/blowfish-download.html
    /// </summary>
    public class Blowfish
    {
        public static readonly byte[] LandlordPassKey =
        {
            0x9C,0x8E,0x74,0xA5,0x3F,0xC0,0x76,0x83,0xF4,0x46,
            0xAF,0x67,0xB6,0xD6,0xFA,0xF9,0x1D,0x58,0xAA,0x47,
            0xA5,0xC4,0x4F,0x01,0xBF,0x9D,0x0E,0xDB,0x93,0x87,
            0xF0,0xA3,0xDB,0xA7,0x84,0x82,0x61,0x86,0xF6,0x40,
        };

        struct BLOWFISH_CTX
        {
            public uint[] P;
            public uint[,] S;
        };

        private BLOWFISH_CTX ctx;

        private byte[] PASS_KEY;

        // These are hexadecimal digits of Pi, from the 140984th place. The place
        // was randomly chosen using HotBits (http://www.fourmilab.ch/hotbits/), with
        // its result of 0x44D7, then scaled by a factor of 8. Note that the digits
        // below are in proper sequence, but since they are stored as DWORDs

        private readonly uint[] PASS_P =
        {
            0xE8248F84, 0xBD44C418, 0x9407E147, 0x2A102D1A,
            0x6F4A422C, 0x92AC2713, 0x2E845789, 0x7A2C0D3A,
            0x874FE1CC, 0x9F9B330A, 0x5DF80E6C, 0x4F636C95,
            0xBCC5F779, 0x5D66B3BD, 0x431089FE, 0xE402ADC2,
            0x029FC331, 0xC177B751
        };

        private readonly uint[,] ORIG_S = new uint[4, 256]
        {
            {

                0x85761AE7, 0xA3B5653F, 0x30638F30, 0x977B7550,
                0x482D2277, 0xFFAC7536, 0x1B506B8D, 0x2F4359D8,
                0xB3D879A6, 0x2264F12B, 0x2E9B7431, 0xE463719C,
                0x295D1E5D, 0x23D2A84F, 0x886946FA, 0xA9D63FE0,
                0xA5F3387E, 0x5C552C6D, 0xD1B55900, 0x5176E919,
                0xF6318001, 0x1ACA1764, 0x5ABC3D78, 0x7DFA2C3F,
                0x6AE184AA, 0x85626910, 0xA499FB2E, 0xAEEC03B0,
                0x680C246E, 0x5BEC7290, 0x73686599, 0x8EB4D3F3,
                0xCF3F67FC, 0xACE2DF4C, 0x8FCCD79E, 0x1A5827FE,
                0xECF05F62, 0xC148F9B8, 0x6C2102B6, 0xAA800BBE,
                0x6B56571A, 0x2464207A, 0x4690E895, 0xAC69277C,
                0xCB9CDB28, 0x5459110A, 0xCEB7FA67, 0x6B3E0ED3,
                0x806ECA81, 0x0FFFABC4, 0x6B0D0033, 0x5480964D,
                0xD6181E27, 0x1156EFE3, 0x9E600D6E, 0x5F34DD48,
                0x18AAF9A1, 0x0EB01C70, 0xA9E79911, 0xE10745EA,
                0x5D38E17A, 0xFD54BC51, 0x12872A2D, 0xCA4EA01B,
                0x853C2D05, 0x30A200B4, 0x133E415F, 0x8F5C433B,
                0x7ADEA464, 0x77A0A6EA, 0xD9FCF57D, 0x6DFFA3AA,
                0x44701786, 0x88BF826E, 0xEEE2BCBE, 0xEA20405D,
                0x9C003188, 0x9EEC12C9, 0xFE3B93F3, 0xFEB54EE2,
                0x4E478522, 0x89B3BC70, 0x7DD58228, 0xD9421E55,
                0x2350D8FE, 0x3992A96F, 0x63153C16, 0xFDDCB186,
                0xE13DBFF2, 0xBB797C62, 0x4E86BEC8, 0xB636BBA0,
                0x68ADA91E, 0x0CDC35C5, 0xDD62FC63, 0xA50285B6,
                0x0962ADE8, 0x1C2FDD84, 0xCEDC362B, 0xF98E1F8F,
                0x0208117B, 0xE6C32CF0, 0xDF1BD32E, 0x30DF7774,
                0x938899C5, 0xBD887A32, 0xC5C73048, 0x8EDAA2A1,
                0xD969799E, 0x8FC93E01, 0xAB6ADFAB, 0xACFC8023,
                0x3415F763, 0x511C68D5, 0x7F41D8D0, 0xEB42C917,
                0x817CB4D1, 0x9C563FAA, 0x732993F2, 0xE15A1481,
                0x264F4C09, 0xC267C7FA, 0xE602ED6D, 0xBD257883,
                0xFF8F5428, 0x24CA1787, 0xFD1CE8C0, 0x5E3887DA,
                0x23ED276D, 0x823D1B47, 0x02200A2E, 0x52C22B8E,
                0x8A4C356A, 0xD3C34117, 0x64B292F5, 0x10382A15,
                0x25D327D3, 0x2A14CBC7, 0x8C7D0A5C, 0x98C5DDF4,
                0x7F954A28, 0x451F7B17, 0xA9D3948A, 0x53FBD6CD,
                0xD878297A, 0x6FDDDC21, 0x5C06CC71, 0x2CC2FC1F,
                0xC9683C01, 0xC48E9083, 0x3AB9A29D, 0x8FB81B22,
                0x709C6A48, 0xDED59816, 0x005E1DC0, 0x8E6E64BC,
                0x5AAD1271, 0xFFD5E7F6, 0x7E406879, 0xE00F39E8,
                0x1A83CA83, 0x76013B35, 0x377D90B9, 0xFA4D08AC,
                0x68C54E86, 0x0F151907, 0xDDBBA28B, 0xCC37909B,
                0x89277D99, 0xCDDA313E, 0x3827D527, 0xCB157969,
                0xA3BDD0B8, 0x018BEDA3, 0xD0C0135F, 0xEB07EDA1,
                0xD54D0BFE, 0xE77C8AE6, 0xDA7D3874, 0x116B2B03,
                0x088E5F5E, 0xA81D7F7F, 0x8A35838B, 0x18DEA716,
                0x7BCDC080, 0xA42371B6, 0xD691AEE8, 0x331774B7,
                0x2C6E5C92, 0x2F861799, 0x9EA320F8, 0xA569EA82,
                0x7BBB3DC2, 0x5B50816D, 0x15AF5366, 0xFC1B6D2F,
                0x5D11D855, 0x62678505, 0x13FDB640, 0xE22F8AE9,
                0x431EC927, 0xBDD96533, 0x3091E18E, 0x2574EFB6,
                0x2465480F, 0xA7EEA4C6, 0x7AECAF08, 0x9347C5A4,
                0xEECF0A5D, 0x0843FE52, 0x57DD331F, 0xE86AB150,
                0x5E938C3A, 0x590AD962, 0x9454A1B8, 0x9279EFC0,
                0x8BF2EFBF, 0x62A1AE86, 0xA532CEFD, 0x3D43E651,
                0x14710C51, 0x46D0085A, 0x1866EC68, 0xA19D7572,
                0xC868316F, 0xCFD27244, 0x1824CECF, 0x43AC40E8,
                0xACDC759A, 0x83F4367A, 0x471B85BA, 0x582EA74C,
                0xB014567D, 0x317C84F5, 0x036D8313, 0xC73B972D,
                0x40C68165, 0x319EA61F, 0xF33CA081, 0xECFC127C,
                0x71DB775E, 0x66BBB7BC, 0x86A0AD3D, 0xDBD08BAA,
                0x23AA65FB, 0x0A95E8DA, 0xBA85EEA3, 0xEABC5501,
                0x8DE83409, 0xD8363B03, 0xDE395FCB, 0xB43DF2CB,
                0xAC068B6C, 0x6C96E452, 0xD1D588DE, 0x896817F0,
            },
            {
                0x07F70E13, 0x9505E5D4, 0xFDE1AE56, 0x963ACC43,
                0x9E28F16A, 0xCB416AE9, 0x2EC6E70B, 0x57B5415D,
                0x0803F6C2, 0xC72D7244, 0xB8123494, 0xDEDECEB8,
                0x7BBB6BFF, 0xBB936045, 0xEB8D9C7A, 0x1AE5309B,
                0xF900A522, 0xFB794AA6, 0x25A79A20, 0xD5C12401,
                0x0035C402, 0x79AFD02C, 0x75A086EB, 0xAEDB1988,
                0x8C4CCE4C, 0xAB3E3D04, 0x4D70AC27, 0x9339D3B6,
                0xAEE90572, 0x80F3A9C4, 0x769BB7A7, 0x0067C8D7,
                0xC15BF3A3, 0x3674C300, 0xF335C30E, 0x2E3BDD93,
                0x40A16342, 0x05021C55, 0xBEEE47E0, 0xF1773758,
                0xE7F2490A, 0xF8D51D71, 0x5B24E699, 0xAE6382EF,
                0xDDC7795A, 0xA4FC65A1, 0xB0FF0433, 0xC8350D95,
                0x1CB773C5, 0xABF0FDA9, 0x4C5CF618, 0x046C4165,
                0x031FEC4D, 0xEAF59350, 0x6D888B7B, 0xB87AA079,
                0x06DDF808, 0x9D858FEF, 0xBBD9F886, 0x60ED2105,
                0xA272DD4B, 0xE2C50956, 0x72C34757, 0x2D021708,
                0xE198688C, 0xCFFC25C9, 0x3EA46FE1, 0xE669A922,
                0xFB5389FF, 0xDC8C1EBA, 0x7E4F87AB, 0x6773CA19,
                0x0A4D10D8, 0xCD902D07, 0x1C63E774, 0xB7F35DC2,
                0x0630BC91, 0xFFBA8E46, 0xA67E4FF5, 0x17299C57,
                0x695ECFB4, 0x11E84AEC, 0xC521E8C4, 0xE1AE342E,
                0xD567A50F, 0xC3C394DD, 0xA8E8A737, 0xADAE34AB,
                0x81D160BE, 0xDA59C3AA, 0xD305FF98, 0xE6392FD8,
                0xF6651F22, 0x0628D66F, 0x79CE983D, 0xE2DA07A1,
                0xBE65B73B, 0x80E9451B, 0x8B207477, 0xB58976B5,
                0xA9BCCDCF, 0x3D5B52DC, 0x44361F7D, 0xBDD8C8C0,
                0x14FF0130, 0xB83EA1F2, 0xBA17BC27, 0x3FD7D966,
                0xB060BFD6, 0x5C64289A, 0xE8A3DB99, 0x6A094AFA,
                0x7E2243ED, 0x3EB8FC7D, 0xBB320F64, 0x04D75552,
                0x9ABF56BD, 0x8D123736, 0x4D87D91E, 0x52ACD457,
                0x487B3020, 0xA0187446, 0x5882C4B0, 0x4B3BBDDE,
                0x347D6CBF, 0xF252F7BD, 0x10C19CC7, 0x05120031,
                0xB7053B0A, 0x98F87EA1, 0x86CC3882, 0x1C62D5A6,
                0x1246E72B, 0x827CCE26, 0x6C278F2B, 0x4FE8EC8C,
                0xFF30E90B, 0x50AFD667, 0x1B8CDF1A, 0xA66699BC,
                0x1F97A448, 0x59563CF7, 0xEE0D9B0F, 0x7AAB0580,
                0x5DDCFBFE, 0x69953779, 0x15820CEB, 0x06EDD086,
                0xD9E83214, 0xD0F594AC, 0xE5627C19, 0x7B3CAB3F,
                0x4D31F205, 0x742FAD38, 0xB60CC9A6, 0x5846093A,
                0x4B20C1EE, 0x76B2AA0D, 0x9623FFC9, 0xE636D037,
                0x34D5A810, 0x15E58CDD, 0x1AD1689E, 0x5AFE08A6,
                0xE0808078, 0x04D759F5, 0x6A2143B1, 0x926EC844,
                0xFA66E9F5, 0x571DAE30, 0x82ACD68D, 0x7CB046E3,
                0xECCB06F0, 0x8BC1100B, 0x9D11CBE6, 0x56818E5E,
                0xABF2C7FE, 0x90697CD3, 0xCFEFC473, 0x3D8C5B24,
                0x00CDF0E6, 0x5AF1EFB6, 0xC38C93EB, 0x2E540E67,
                0xB1D22F3F, 0xA903BB26, 0x2D4B1BDD, 0xC838DFAB,
                0x27488401, 0x0102BD3E, 0x1A6CE964, 0xBF5D8FFB,
                0xE8532AC6, 0xBBF3A621, 0xEC8CB004, 0x4392D100,
                0x7763673A, 0x1EDA9E62, 0x41D028CA, 0xA2B6B799,
                0x7DFCDCDD, 0xF8766B04, 0x029D28D8, 0x74E8755B,
                0x073AC803, 0x6119838E, 0x18B572B1, 0xF1D7817A,
                0x1BD18D79, 0x205AF62A, 0xCA1A7311, 0x90164C18,
                0x9080DE56, 0x2E568832, 0x6EA5BE0E, 0xC6067627,
                0x7F6FBF6D, 0x1AC8C921, 0x002BF4BD, 0x416FFF8E,
                0xEA5E7B9F, 0x4812BD8C, 0xEE90AB72, 0xE26C9F43,
                0x0398B9C8, 0x14727F69, 0xE062B0C2, 0xD23E22D4,
                0x895990B9, 0x05E584F9, 0xA3A054EA, 0x03F3BEBE,
                0x9E981263, 0x7980E243, 0xA54A2701, 0x02C45392,
                0x647372B0, 0x93935063, 0xF2CD5E6F, 0xE3FAE56C,
                0x9CAA65C5, 0x307464CE, 0x5435AD49, 0xCA5FA5A4,
                0x835E02B9, 0xE447BEC9, 0x0452E748, 0x2710ECC8,
                0x0D67B43F, 0xF7B04FCE, 0x24DB9C0E, 0x2A10731B,
                0xAEC5F8CB, 0x91B31012, 0x185DF1F9, 0x6A4E2FB2,
            },
            {
                0x134A0EF8, 0x1525A97A, 0x523D161F, 0xAA2D1880,
                0x806B628A, 0xDAB28F16, 0xBB80823C, 0x89B842F7,
                0x35EA406B, 0x64BD937D, 0xA511B35F, 0xBA3B74BF,
                0xFE55F36C, 0xF1A6E8A1, 0x35534905, 0x97D1E3EA,
                0x3BD556C2, 0x62B20A2F, 0x66BBD4C1, 0xFF55EF60,
                0x3618EA93, 0xD55D8F8C, 0x1B219461, 0xA6131FAA,
                0x152CF258, 0xCDEFD43B, 0xF193A3BB, 0x65A0F1EA,
                0xE56E9DAB, 0x74AC9214, 0x1B47D098, 0xABBA799A,
                0x3DF0A9F4, 0xFBE69D0D, 0xF4539563, 0xB4611E29,
                0xFF40DCAA, 0x95039AB6, 0x2947EE33, 0x3FE6C99B,
                0xB2EE4003, 0xC61D9A59, 0x8660C486, 0x4FE85CC6,
                0x816E2DD7, 0xD510D3E1, 0xABEF229A, 0xF51FB9AE,
                0x9FAC571C, 0x4C14EE5D, 0x7217A1D5, 0xBF0D0BF6,
                0xD91F1AD9, 0x30AF3FD5, 0xE6F54042, 0x05BBCE4A,
                0x0CFA4FC2, 0xF21750BD, 0x2CFA258A, 0x4A93CFF1,
                0x8CCB8CC7, 0xC8EDBC51, 0x13944BF8, 0x6B50898A,
                0x4C59D065, 0xE7D67ED7, 0x79AE6D5D, 0xB349EC90,
                0xDE069FAF, 0x3C3E5E59, 0xCFFD155E, 0x07B7291F,
                0x8F01D84B, 0xCE9A3B0C, 0x05271F76, 0x8FCC35C8,
                0xA5DFA91B, 0xE686017F, 0xC61D201B, 0xA4F8DC7F,
                0x5E12979D, 0x1E997F4D, 0x80C03A32, 0xA940CB8F,
                0xB55D1479, 0xE015C0DC, 0x7DAADFAF, 0xD0960CC5,
                0xC03DCDF9, 0xA006E2D7, 0x140028BF, 0x4ED9B6A9,
                0xF9B45D00, 0x16B3A380, 0xEFFADA8E, 0x8CF181DA,
                0xE44E2DDC, 0xB151B6EE, 0xDA62A90F, 0xEE889EF9,
                0x26211478, 0xBE48E541, 0xE2923EDB, 0x45CCF0E7,
                0xEDC5FD8C, 0xF9B31918, 0xA8457FF0, 0x610CD5E8,
                0x9AFE9CE9, 0x32FC4731, 0x3B493C6A, 0xCD0D5704,
                0xAF3B4C93, 0xB205B94C, 0xDE7EE203, 0x597521C9,
                0x977807B7, 0x2672700C, 0x3AE8B437, 0x04159AF5,
                0x4BC94F8D, 0x3B1663F9, 0x029803FA, 0x063B554C,
                0x89BEB050, 0x1102040D, 0x93B79818, 0x3833036B,
                0x697E4103, 0xCB8B263A, 0x0BE1D966, 0xDFA741DF,
                0x0299E619, 0x7AE0BC82, 0x48B118A1, 0xD5948AB2,
                0xA655CA65, 0xCA9E30DA, 0x117069C9, 0x1E7B8410,
                0x080457A0, 0x9724C13F, 0xD755A1D3, 0xBD52D074,
                0x67BB4AE1, 0xC6ABB841, 0x9291BE70, 0x403115D7,
                0x7FDD0F21, 0x1BF66DE6, 0x66DD9141, 0x6F5A9AD1,
                0x6A703F86, 0x2ECCDD15, 0x7DD2B4BA, 0x766ED9DC,
                0x996E1A4C, 0xB9E0ED5A, 0x7C621488, 0x53B39FAE,
                0xD1DCC4F2, 0x454EA6A2, 0xEBF2D834, 0x7C0FDC6F,
                0xC3709B3A, 0xC1BE5D4E, 0x79FABFA3, 0x03724CDE,
                0x8810B793, 0x3D3D7C0D, 0x4829EB36, 0x78B3E76B,
                0x7C4695A5, 0x81BB1174, 0x5C106549, 0x09090F49,
                0xDC7455E6, 0xE188D884, 0x23E2F61C, 0x1B58F268,
                0x827B640D, 0xA47C7400, 0x3831A33A, 0x288FD7D8,
                0x1F03AAF5, 0x114B80E6, 0x3DF327EC, 0xEEDD6BE3,
                0x231F0525, 0x871AAE56, 0x33FD547A, 0x5F3FAADA,
                0x4F29BB10, 0xC90872DF, 0x6DAAEB00, 0x597CF33B,
                0xDB4494F8, 0x4A427003, 0x75DE2E9C, 0x53E37ADE,
                0xE0A6EE90, 0x75F6D5AE, 0xEE97B1B2, 0xE14807A8,
                0xC57F96D8, 0x6BA68A53, 0x6039761C, 0xFAFAB9A6,
                0x1189F09B, 0x0D8A029E, 0xF3BCD75B, 0x8246ECD4,
                0xEFDC8B32, 0x9A88872D, 0x1D49909A, 0xDA3A54B5,
                0xD1741C92, 0x5778E077, 0xCCEED225, 0x98FBC821,
                0xF24661F9, 0x343F941A, 0xFC56A2A3, 0x0D1DBC6A,
                0x014209F4, 0xEAA5AD0A, 0xA387FB9C, 0xB53B3FA8,
                0xAA791104, 0xFBB5BA9F, 0x0453AE84, 0x4EB324EC,
                0xD13D9945, 0x3BA666F0, 0x1AD633B1, 0xF8FAB376,
                0x68E3AC5E, 0x8521816E, 0x220B701D, 0x6D10C7E5,
                0xB9287F67, 0xAE6D4748, 0xACF65D7F, 0xBA21A136,
                0x38AA843F, 0x1D96452E, 0xF886B5DC, 0x70DCAD2F,
                0x104925D5, 0xDF784F83, 0x2F078793, 0xDA16826D,
                0xDCF9B434, 0xCC0691EC, 0xDF0DB47F, 0x2FFEFE69
            },
            {
                0xCA1A5200, 0x712C1C30, 0xF6E9B9B7, 0x47F36F24,
                0xACDB26D0, 0x160A7CA9, 0x35FF8C52, 0x98315148,
                0x51A17EFD, 0xDDA456B2, 0xF0A898FE, 0x3D448084,
                0x9674D164, 0xE2CF868D, 0x59159830, 0x9383EA45,
                0x88E83F40, 0x81F567F7, 0x5279FCDA, 0x771F6ED7,
                0xB0D7B8C2, 0x58CED244, 0x0A0866EB, 0x7A3A861D,
                0x5362E0FF, 0x161D03ED, 0x5E433496, 0x7C1E0971,
                0x9CA422C2, 0x1EE5EEBE, 0xCF5CF639, 0x62F989E7,
                0x8E9C7060, 0xD5A0F0D5, 0x797B645B, 0x002C341B,
                0x7AC57C35, 0x27DC5974, 0xA593600C, 0xEA12C26C,
                0xF4E6BC42, 0x58146071, 0x61BBD46D, 0x58608235,
                0x31E7D0BA, 0xC3EFED48, 0x624EF6A1, 0x1991DD11,
                0x45BCFBF9, 0xDD4D4A1C, 0x4739EB13, 0x36236E36,
                0xC49048A9, 0x62781FF4, 0x76F0AF3E, 0x27E5B569,
                0xAF458157, 0xFC9E4BDB, 0x10D0B25C, 0x05EE5070,
                0x5EA9422F, 0xBAFA998C, 0xA6EB489F, 0x7BF6A6AD,
                0xDDF5B3E9, 0xECD71D8C, 0x931AB97E, 0xC2BD6893,
                0x16F2ABAD, 0xE5326DC0, 0x5D57877F, 0x6B4215D0,
                0x81FF3AB8, 0xA8DD258B, 0xC3835AE6, 0xE9CBDFFE,
                0xE2B7F1FF, 0xDE6452B8, 0x806D19C3, 0x2F277DA4,
                0xE0664946, 0xD95D0EFE, 0x4C1C4FBF, 0x1D1EEE5F,
                0x8DB6D5B4, 0x84EB8876, 0x5F919365, 0x40981D58,
                0xDE33AE43, 0x64E6742F, 0x01B84127, 0x9C716935,
                0x5FCF491E, 0x36C50532, 0x12631354, 0xBFD625B5,
                0x70269FAF, 0x13164B55, 0xC4C29624, 0x4464DE86,
                0xA81E6B53, 0xC015C7A6, 0x4494F266, 0x6D973572,
                0x3F8A41E7, 0xA3ED1D81, 0xBF1A7E5D, 0xF8729C82,
                0xA60F7B50, 0x09789B9D, 0x6F7B639C, 0x460A9E26,
                0xE8C817FA, 0x0F17638A, 0x1ACB497A, 0x26E20CCB,
                0x4A18C979, 0x4254FCF8, 0x24C52864, 0x255DAF23,
                0x98EC3FC6, 0xA31EF9E5, 0x244E292E, 0x88DA8D3F,
                0x2F8AAC4B, 0xA69ECE91, 0x3315531F, 0xAD0C7D93,
                0x53DF625E, 0x3C188EBE, 0xF30A1278, 0x61C8D73D,
                0xD058F13F, 0x93A73A94, 0x8EB497BD, 0x73AAE12B,
                0xD9C6406D, 0xC966487F, 0x65D278CA, 0xF6790D57,
                0xE4C79DC6, 0xEF84DA02, 0xD2888C46, 0x7AAB1B20,
                0x443CBB36, 0x47718E7E, 0x08223AC7, 0xE3474FF2,
                0x6281437C, 0x7BF13A87, 0x7312E009, 0xC1D383B9,
                0xC83A94E7, 0xE7D674E8, 0x9E314100, 0xAECDA7E9,
                0x6B1798E2, 0xF7A8A20F, 0xD11DCB60, 0xEDFC6C10,
                0x3F2F5CDC, 0x1B4F5D07, 0x285CB705, 0xE506B5D6,
                0x62E916E5, 0x01F8ECC3, 0x3D2ABB72, 0x03498A02,
                0x18827FBE, 0x531ED231, 0x00F4D445, 0xE3BD965D,
                0x54459323, 0xC4C53BC2, 0xF4D69A80, 0xE43890FD,
                0x9F6F2CDE, 0xB9D0B80E, 0xE44FCA6B, 0xAEACB3B3,
                0xF46D2596, 0x7A930AF5, 0x703DB060, 0x040D31B6,
                0x5D477A6A, 0x5040BAE5, 0x51B841D9, 0x5EBACE6F,
                0xB29F4E31, 0x07554E0E, 0xAA05EA63, 0xCBFFF2AD,
                0xD1EB07AF, 0x92B42C45, 0x00BA0249, 0xD6A285B0,
                0x1F7FBEBD, 0xF026AEAF, 0x8B5B5351, 0xAD94DA9C,
                0xA4BEFCA4, 0x3BA7CABB, 0x5FD194B4, 0x2936E614,
                0xAAD91775, 0x180E48D0, 0xFF2E1E31, 0xE05763A1,
                0x5DB8EC8A, 0x23A25290, 0xEA30FAEF, 0x13833034,
                0x890B582C, 0xA2A8D047, 0x4C974CBA, 0x778AA9B6,
                0x2E2284B4, 0x26FEFB9F, 0x7479A1B9, 0x1C3E0766,
                0x58462B84, 0xA64E93DD, 0x257DD9A6, 0xEE8299B4,
                0xD2D15B60, 0xA0CED0DB, 0xE5BFCDA7, 0x9DB7F0DD,
                0x6895623C, 0x1499829E, 0x0F6E87DE, 0x730C23F9,
                0xD0EBDC49, 0xEE9F6D17, 0x88013381, 0x52E33903,
                0x8F68C8F3, 0xE51BD0AA, 0x29190AB5, 0x822B793C,
                0x21DC0896, 0x72438CB2, 0xBAEF3F5B, 0x8C5FAC00,
                0x5B010083, 0x1063CD5E, 0x8D2C4C8B, 0xDE50CEED,
                0x072CC7CE, 0x205FD492, 0x1E81468C, 0x0911593C,
                0x7A4C7F85, 0xC78BABF3, 0x9E6F2F4F, 0x57552C3A
            }
        };


        private static uint F(BLOWFISH_CTX ctx, uint x)
        {
            byte a, b, c, d;
            uint y;

            d = (byte)(x & 0xFF);
            x >>= 8;
            c = (byte)(x & 0xFF);
            x >>= 8;
            b = (byte)(x & 0xFF);
            x >>= 8;
            a = (byte)(x & 0xFF);
            y = ctx.S[0, a] + ctx.S[1, b];
            y = y ^ ctx.S[2, c];
            y = y + ctx.S[3, d];

            return y;
        }

        private void Blowfish_Decrypt(ref uint xl, ref uint xr)
        {
            uint Xl;
            uint Xr;
            uint temp;
            short i;

            Xl = xl;
            Xr = xr;

            for (i = 16 + 1; i > 1; --i)
            {
                Xl = Xl ^ ctx.P[i];
                Xr = F(ctx, Xl) ^ Xr;

                /* Exchange Xl and Xr */
                temp = Xl;
                Xl = Xr;
                Xr = temp;
            }

            /* Exchange Xl and Xr */
            temp = Xl;
            Xl = Xr;
            Xr = temp;

            Xr = Xr ^ ctx.P[1];
            Xl = Xl ^ ctx.P[0];

            xl = Xl;
            xr = Xr;
        }

        private void Blowfish_Encrypt(ref uint xl, ref uint xr)
        {
            short i;
            uint temp;

            uint Xl = xl;
            uint Xr = xr;

            for (i = 0; i < 16; ++i)
            {
                Xl = Xl ^ ctx.P[i];
                Xr = F(ctx, Xl) ^ Xr;

                temp = Xl;
                Xl = Xr;
                Xr = temp;
            }

            temp = Xl;
            Xl = Xr;
            Xr = temp;

            Xr = Xr ^ ctx.P[16];
            Xl = Xl ^ ctx.P[16 + 1];

            xl = Xl;
            xr = Xr;
        }

        private void Blowfish_Init(byte [] passkey)
        {
            int i, j, k;
            uint data, datal, datar;

            PASS_KEY = passkey;

            ctx = new BLOWFISH_CTX();

            ctx.S = new uint[4, 256];
            ctx.P = new uint[16 + 2];

            for (i = 0; i < 16 + 2; ++i)
                ctx.P[i] = PASS_P[i];

            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 256; j++)
                    ctx.S[i, j] = ORIG_S[i, j];
            }

            j = 0;
            for (i = 0; i < 16 + 2; ++i)
            {
                data = 0x00000000;
                for (k = 0; k < 4; ++k)
                {
                    data = (data << 8) | PASS_KEY[j];
                    j = j + 1;
                    if (j >= PASS_KEY.Length)
                        j = 0;
                }
                ctx.P[i] ^= data;
            }

            datal = 0x00000000;
            datar = 0x00000000;

            for (i = 0; i < 16 + 2; i += 2)
            {
                Blowfish_Encrypt(ref datal, ref datar);
                ctx.P[i] = datal;
                ctx.P[i + 1] = datar;
            }

            for (i = 0; i < 4; ++i)
            {
                for (j = 0; j < 256; j += 2)
                {
                    Blowfish_Encrypt(ref datal, ref datar);
                    ctx.S[i, j] = datal;
                    ctx.S[i, j + 1] = datar;
                }
            }
        }

        private byte[] Blowfish_Decrypt(byte[] encrypt)
        {
            var decrypt = new byte[encrypt.Length];

            for (int i = 0; i < encrypt.Length / 8; i++)
            {
                uint xl = BitConverter.ToUInt32(encrypt, i * 8);
                uint xr = BitConverter.ToUInt32(encrypt, i * 8 + 4);

                Blowfish_Decrypt(ref xl, ref xr);

                System.Array.Copy(BitConverter.GetBytes(xl), 0, decrypt, i * 8, 4);
                System.Array.Copy(BitConverter.GetBytes(xr), 0, decrypt, i * 8 + 4, 4);
            }

            return decrypt;
        }

        /// <summary>
        /// Encrypts a plaintext byte array
        /// </summary>
        /// <param name="plainTextBytes">byte array converted from a plaintext string</param>
        /// <returns>encrypted byte array</returns>
        private byte[] Blowfish_Encrypt(byte[] plainTextBytes)
        {
            var encrypted = new byte[plainTextBytes.Length];
            for (var i = 0; i < plainTextBytes.Length / 8; i++)
            {
                var xl = BitConverter.ToUInt32(plainTextBytes, i * 8);
                var xr = BitConverter.ToUInt32(plainTextBytes, i * 8 + 4);

                Blowfish_Encrypt(ref xl, ref xr);

                Array.Copy(BitConverter.GetBytes(xl), 0, encrypted, i * 8, 4);
                Array.Copy(BitConverter.GetBytes(xr), 0, encrypted, i * 8 + 4, 4);
            }
            return encrypted;
        }


        /// <summary>
        /// blowfish decryption algorithm
        /// </summary>
        /// <param name="password_key">40-byte password key</param>
        /// <param name="encrypt">encrypted string</param>
        /// <returns>decrypted string</returns>
        public static string Blowfish_Decrypt(byte[] password_key, string encrypt)
        {
            var encryptBytes =
                Enumerable.Range(0, encrypt.Length)
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(encrypt.Substring(x, 2), 16))
                    .ToArray();

            var bf = new Blowfish();

            bf.Blowfish_Init(password_key);

            var decryptBytess = bf.Blowfish_Decrypt(encryptBytes);

            return System.Text.Encoding.UTF8.GetString(decryptBytess).Trim('\0').Trim();
        }

        /// <summary>
        /// Encrypts a plaintext via blowfish
        /// </summary>
        /// <param name="passwordKey">40-byte password key</param>
        /// <param name="plainText">string to be encrypted</param>
        /// <returns>encrypted string</returns>
        public static string Blowfish_Encrypt(byte[] passwordKey, string plainText)
        {
            var bf = new Blowfish();

            bf.Blowfish_Init(passwordKey);

            var plainTextByteList = Encoding.ASCII.GetBytes(plainText).ToList();

            // pad input to a multiple of 8 byte blocks as required by blowfish
            for (var padding = 8 - (plainTextByteList.Count % 8); padding > 0 && padding < 8; padding--)
                plainTextByteList.Add(0);

            var encryptedBytes = bf.Blowfish_Encrypt(plainTextByteList.ToArray());

            var result = BitConverter.ToString(encryptedBytes).Replace("-", "");
            return result;
        }
    }
}
