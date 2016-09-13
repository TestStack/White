using System;
using System.Runtime.InteropServices;

namespace TestStack.White.WindowsAPI
{
    /// <summary>
    /// Provides methods which activate Windows Store apps for the Launch, File, and Protocol extensions.
    /// You will normally use this interface in debuggers and design tools. For instance, Microsoft Visual StudioIDE and Microsoft Expression Blend use this interface because both need to activate apps for the Launch contract to support F5 debugging.
    /// </summary>
    [ComImport, Guid("2e941141-7f97-4756-ba1d-9decde894a3d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface IApplicationActivationManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appUserModelId"></param>
        /// <param name="arguments"></param>
        /// <param name="options"></param>
        /// <param name="processId"></param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        IntPtr ActivateApplication([In] String appUserModelId, [In] String arguments, [In] ActivateOptions options, [Out] out UInt32 processId);
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appUserModelId"></param>
        /// <param name="itemArray"></param>
        /// <param name="verb"></param>
        /// <param name="processId"></param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        IntPtr ActivateForFile([In] String appUserModelId, [In] IntPtr /*IShellItemArray* */ itemArray, [In] String verb, [Out] out UInt32 processId);
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appUserModelId"></param>
        /// <param name="itemArray"></param>
        /// <param name="processId">If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</param>
        /// <returns></returns>
        IntPtr ActivateForProtocol([In] String appUserModelId, [In] IntPtr /* IShellItemArray* */itemArray, [Out] out UInt32 processId);
    }
}