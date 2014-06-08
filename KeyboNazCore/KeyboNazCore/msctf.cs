using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace KeyboNazCore
{

    //msctf.idl
    [ComImport,
    Guid("3D61BF11-AC5F-42C8-A4CB-931BCC28C744"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumTfLanguageProfiles
    {
        [return: MarshalAs(UnmanagedType.IUnknown)]
        IEnumTfLanguageProfiles Clone();
        //[PreserveSig]
        //Int32 Next(
        //    UInt32 ulCount,
        //    TF_LANGUAGEPROFILE - ? - COM Interop Part 8
        //    )
        //Reset
        //Skip
    }

    /*
     * reference
     * http://blogs.msdn.com/b/adam_nathan/archive/2003/04/23/56635.aspx
     * http://www.pinvoke.net/default.aspx/Interfaces/IMetaDataDispenser.html
     */
    //msctf.idl
    [ComImport,
    Guid("1F02B6C5-7842-4EE6-8A0B-9A24183A95CA"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ITfInputProcessorProfiles
    {
        void Register([MarshalAs(UnmanagedType.LPStruct)] Guid rclsid);
        //Unregister
        void AddLanguageProfile(
            [MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
            UInt16 langid,
            [MarshalAs(UnmanagedType.LPStruct)] Guid guidProfile,
            [MarshalAs(UnmanagedType.LPWStr)] String pchDesc,
            UInt32 cchDesc,
            [MarshalAs(UnmanagedType.LPWStr)] String pchIconFile,
            UInt32 cchFile,
            UInt32 uIconIndex);
        //RemoveLanguageProfile
        [return: MarshalAs(UnmanagedType.IUnknown)]
        IEnumGUID EnumInputProcessorInfo();
        //GetDefaultLanguageProfile
        //SetDefaultLanguageProfile
        void ActivateLaunguageProfile(
            [MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
            UInt16 langid,
            [MarshalAs(UnmanagedType.LPStruct)] Guid guidProfiles);
        //GetActiveLanguageProfile
        //GetLanguageProfileDescription
        //GetCurrentLanguage
        void ChangeCurrentLanguage(UInt16 langid);
        //GetLanguageList
        [return: MarshalAs(UnmanagedType.IUnknown)]
        IEnumTfLanguageProfiles EnumLanguageProfiles(UInt16 langid);
        void EnableLanguageProfile(
            [MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
            UInt16 langid,
            [MarshalAs(UnmanagedType.LPStruct)] Guid guidProfile,
            [MarshalAs(UnmanagedType.Bool)] Boolean fEnable);
        void EnableLanguageProfileByDefault(
            [MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
            UInt16 langid,
            [MarshalAs(UnmanagedType.LPStruct)] Guid guidProfile,
            [MarshalAs(UnmanagedType.Bool)] Boolean fEnable);
        //SubstituteKeyboardLayout
    }
}
