using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace KeyboNazCore
{
    //GUID http://stackoverflow.com/questions/2631120/com-interface-guid
    //comcat.idl
    [ComImport,
    Guid("0002E000-0000-0000-C000-000000000046"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumGUID
    {
        [PreserveSig]
        Int32 Next(
            UInt32 celt,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] out Guid[] rgelt,
            out UInt32 pceltFetched);
        void Skip(UInt32 celt);
        void Reset();
        [return: MarshalAs(UnmanagedType.IUnknown)]
        IEnumGUID Clone();
    }
}
