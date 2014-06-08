using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace KeyboNazCore
{
    //GUID http://stackoverflow.com/questions/2631120/com-interface-guid
    [ComImport, 
    Guid("0002E000-0000-0000-C000-000000000046"), 
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumGUID
    {
        [PreserveSig]
        Int32 Next(
            UInt32 celt,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex=0)] out Guid[] rgelt,
            out UInt32 pceltFetched);
        void Skip(UInt32 celt);
        void Reset();
        [return: MarshalAs(UnmanagedType.IUnknown)]
        IEnumGUID Clone();
    }

    [ComImport,
    Guid("3D61BF11-AC5F-42C8-A4CB-931BCC28C744"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumTfLanguageProfiles
    {
        [return: MarshalAs(UnmanagedType.IUnknown)]
        IEnumTfLanguageProfiles Clone();
    }

    /*
     * reference
     * http://blogs.msdn.com/b/adam_nathan/archive/2003/04/23/56635.aspx
     * http://www.pinvoke.net/default.aspx/Interfaces/IMetaDataDispenser.html
     */
    [ComImport,
    Guid("1F02B6C5-7842-4EE6-8A0B-9A24183A95CA"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ITfInputProcessorProfiles
    {
        void ActivateLaunguageProfile(
            [MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
            UInt16 langid,
            [MarshalAs(UnmanagedType.LPStruct)] Guid guidProfiles);
        void AddLanguageProfile(
            [MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
            UInt16 langid,
            [MarshalAs(UnmanagedType.LPStruct)] Guid guidProfile,
            [MarshalAs(UnmanagedType.LPWStr)] String pchDesc,
            UInt32 cchDesc,
            [MarshalAs(UnmanagedType.LPWStr)] String pchIconFile,
            UInt32 cchFile,
            UInt32 uIconIndex);
        void ChangeCurrentLanguage(UInt16 langid);
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
        [return: MarshalAs(UnmanagedType.IUnknown)]
        IEnumGUID EnumInputProcessorInfo();
        void EnumLanguageProfiles(
            UInt16 langid
            
            );
        void Register([MarshalAs(UnmanagedType.LPStruct)] Guid rclsid);
    }

    public class TextServicesFramework
    {
        public static ITfInputProcessorProfiles getInputProcessProfiles()
        {
            //http://www.pinvoke.net/default.aspx/ole32.cocreateinstance
            Guid CLSID_TF_InputProcessorProfiles = new Guid("33C53A50-F456-4884-B049-85FD643ECFED");
            Type inputProcessorProfilesType = Type.GetTypeFromCLSID(CLSID_TF_InputProcessorProfiles);
            return (ITfInputProcessorProfiles)Activator.CreateInstance(inputProcessorProfilesType);
        }
    }
}
