using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

/*
 * 1. Method order should be same as written in IDL (COM Interop Part 6)
 * 2. This return value extraction works when the last parameter
 * of the method is an out parameter, and the return value of
 * the method is an HRESULT. (COM Interop Part 6)
 */

namespace KeyboNazCore
{
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
