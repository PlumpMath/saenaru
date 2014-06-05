using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace KeyboNazCore
{
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
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
            [In] UInt16 langid,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guidProfiles);
        void AddLanguageProfile(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
            [In] UInt16 langid,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guidProfile,
            [In, MarshalAs(UnmanagedType.LPWStr)] String pchDesc,
            [In] UInt32 cchDesc,
            [In, MarshalAs(UnmanagedType.LPWStr)] String pchIconFile,
            [In] UInt32 cchFile,
            [In] UInt32 uIconIndex);

        void Register([In, MarshalAs(UnmanagedType.LPStruct)] Guid rclsid);
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
