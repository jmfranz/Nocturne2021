#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>


template <typename R>
struct VirtFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename R, typename T1>
struct GenericVirtFuncInvoker1
{
	typedef R (*Func)(void*, T1, const RuntimeMethod*);

	static inline R Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		return ((Func)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename R>
struct InterfaceFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
struct InterfaceActionInvoker0
{
	typedef void (*Action)(void*, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, invokeData.method);
	}
};

// System.Threading.AsyncLocal`1<System.Globalization.CultureInfo>
struct AsyncLocal_1_t480A201BA0D1C62C2C6FA6598EEDF7BB35D85349;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_tC94E9875910491F8130C2DC8B11E4D1548A55162;
// System.EventHandler`1<Bespoke.Common.ExceptionEventArgs>
struct EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F;
// System.EventHandler`1<System.Object>
struct EventHandler_1_tFA1C30E54FA1061D79E711F65F9A174BFBD8CDCB;
// System.EventHandler`1<Bespoke.Common.Osc.OscBundleReceivedEventArgs>
struct EventHandler_1_t129E585D9AA40035BC8D64CA9AE2FB4166FD9AC4;
// System.EventHandler`1<Bespoke.Common.Osc.OscMessageReceivedEventArgs>
struct EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714;
// System.EventHandler`1<Bespoke.Common.Osc.OscPacketReceivedEventArgs>
struct EventHandler_1_t0AFB60D05E9FCFB34BD7F25226CC0CEE2E7271E4;
// System.EventHandler`1<Bespoke.Common.Net.TcpConnectionEventArgs>
struct EventHandler_1_t3782CAFC23B84FE2565AA899369F210C80E75ECF;
// System.EventHandler`1<Bespoke.Common.Net.TcpDataReceivedEventArgs>
struct EventHandler_1_tEFAA9D3F682231A3C61310E1CE32DB931BBBAE43;
// System.EventHandler`1<Bespoke.Common.Net.UdpDataReceivedEventArgs>
struct EventHandler_1_tEFE51D141A816E328C23211083B6A5CDCAAF1BED;
// System.Collections.Generic.IList`1<System.Object>
struct IList_1_t707982BD768B18C51D263C759F33BCDBDFA44901;
// System.Collections.Generic.List`1<System.Byte>
struct List_1_tD0117BC32B3DBF148E7E9AC108FC376C3D4922CF;
// System.Collections.Generic.List`1<System.Object>
struct List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5;
// System.Collections.Generic.List`1<System.String>
struct List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3;
// System.Collections.Generic.List`1<Bespoke.Common.Net.TcpConnection>
struct List_1_t8437E2CEB9C2C34412935AD0B393192619E1C7C8;
// System.Collections.ObjectModel.ReadOnlyCollection`1<System.Object>
struct ReadOnlyCollection_1_t921D1901AD35062BE31FAEB0798A4B814F33A3C3;
// System.Byte[]
struct ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726;
// System.Char[]
struct CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34;
// System.Delegate[]
struct DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8;
// System.Int32[]
struct Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32;
// System.IntPtr[]
struct IntPtrU5BU5D_t27FC72B0409D75AAF33EC42498E8094E95FEE9A6;
// System.Object[]
struct ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE;
// System.Diagnostics.StackTrace[]
struct StackTraceU5BU5D_t4AD999C288CB6D1F38A299D12B1598D606588971;
// System.String[]
struct StringU5BU5D_tACEBFEDE350025B554CD507C9AE8FFE49359549A;
// System.UInt16[]
struct UInt16U5BU5D_t42D35C587B07DCDBCFDADF572C6D733AE85B2A67;
// System.AsyncCallback
struct AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA;
// System.IO.BinaryReader
struct BinaryReader_t4F45C15FF44F8E1C105704A21FFBE58D60015128;
// System.IO.BinaryWriter
struct BinaryWriter_t70074014C7FE27CD9F7500C3F02C4AB61D35554F;
// System.Globalization.CultureInfo
struct CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98;
// System.Delegate
struct Delegate_t;
// System.DelegateData
struct DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288;
// System.Net.EndPoint
struct EndPoint_t18D4AE8D03090A2B262136E59F95CE61418C34DA;
// System.EventArgs
struct EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA;
// System.Exception
struct Exception_t;
// Bespoke.Common.ExceptionEventArgs
struct ExceptionEventArgs_t1207BC0BED111D8BEA61607413C2A139F8A1DDC0;
// System.Threading.ExecutionContext
struct ExecutionContext_t16AC73BB21FEEEAD34A017877AC18DD8BB836414;
// System.IAsyncResult
struct IAsyncResult_tC9F97BF36FCF122D29D3101D80642278297BF370;
// System.Collections.IDictionary
struct IDictionary_t99871C56B8EC2452AC5C4CF3831695E617B89D3A;
// System.IOAsyncCallback
struct IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E;
// System.Net.IPAddress
struct IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE;
// System.Net.IPEndPoint
struct IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E;
// Bespoke.Common.Net.IPServer
struct IPServer_tBEF36D7D3CD1DEBACE97ACE01D198E4EA25D3C06;
// System.Security.Principal.IPrincipal
struct IPrincipal_t850ACE1F48327B64F266DD2C6FD8C5F56E4889E2;
// System.Threading.InternalThread
struct InternalThread_t12B78B27503AE19E9122E212419A66843BF746EB;
// System.InvalidOperationException
struct InvalidOperationException_t10D3EE59AD28EC641ACEE05BCA4271A527E5ECAB;
// System.LocalDataStoreHolder
struct LocalDataStoreHolder_tF51C9DD735A89132114AE47E3EB51C11D0FED146;
// System.LocalDataStoreMgr
struct LocalDataStoreMgr_t6CC44D0584911B6A6C6823115F858FC34AB4A80A;
// System.Threading.ManualResetEvent
struct ManualResetEvent_t9E2ED486907E3A16122ED4E946534E4DD6B5A7BA;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// System.MulticastDelegate
struct MulticastDelegate_t;
// System.Net.Sockets.NetworkStream
struct NetworkStream_t160A2538024FE3EC707872435D01F1C20B3B1A48;
// Bespoke.Common.Osc.OscBundle
struct OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41;
// Bespoke.Common.Osc.OscBundleReceivedEventArgs
struct OscBundleReceivedEventArgs_t1ABF2F51A974BCF1B4328DCA66A094C2D6AB6345;
// Bespoke.Common.Osc.OscClient
struct OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591;
// Bespoke.Common.Osc.OscMessage
struct OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2;
// Bespoke.Common.Osc.OscMessageReceivedEventArgs
struct OscMessageReceivedEventArgs_t8E8CE6EC7E84AF0892F400AB363313C22B8C4E83;
// Bespoke.Common.Osc.OscPacket
struct OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5;
// Bespoke.Common.Osc.OscPacketReceivedEventArgs
struct OscPacketReceivedEventArgs_t61CB29F943015645037B535D6348EA15E19C680B;
// Bespoke.Common.Osc.OscServer
struct OscServer_tEC9090B8C05007FBB204BE388A8707862015E025;
// Bespoke.Common.Osc.OscTimeTag
struct OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB;
// System.Runtime.Serialization.SafeSerializationManager
struct SafeSerializationManager_tDE44F029589A028F8A3053C5C06153FAB4AAE29F;
// System.Net.Sockets.SafeSocketHandle
struct SafeSocketHandle_t5050671179FB886DA1763A0E4EFB3FCD072363C9;
// System.Threading.SemaphoreSlim
struct SemaphoreSlim_t3EF85FC980AE57957BEBB6B78E81DE2E3233D385;
// System.Net.Sockets.Socket
struct Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09;
// System.String
struct String_t;
// System.Net.Sockets.TcpClient
struct TcpClient_t0EEB05EA031F6AFD93D46116F5E33A9C4E3350EE;
// Bespoke.Common.Net.TcpConnection
struct TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129;
// Bespoke.Common.Net.TcpDataReceivedEventArgs
struct TcpDataReceivedEventArgs_t2A59DD027A324B15BAE90E0AC00122E825EDF4B3;
// Bespoke.Common.Net.TcpServer
struct TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17;
// System.Threading.Thread
struct Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414;
// System.Threading.ThreadStart
struct ThreadStart_tA13019555BA3CB2B0128F0880760196BF790E687;
// System.Net.Sockets.UdpClient
struct UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920;
// Bespoke.Common.Net.UdpDataReceivedEventArgs
struct UdpDataReceivedEventArgs_t148E7E67B81BD9271877379526876EBCA1A0B7F0;
// Bespoke.Common.Net.UdpServer
struct UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2;
// System.Void
struct Void_t700C6383A2A510C2CF4DD86DABD5CA9FF70ADAC5;

IL2CPP_EXTERN_C RuntimeClass* BitConverter_t8DCBA24B909F1B221372AF2B37C76DCF614BA654_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Char_tFF60D8E7E89A20BE2294A003734341BD1DF43E14_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Color_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Double_t42821932CB52DE2057E685D0E1AF3DE5033D2181_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* EventHandler_1_tEFAA9D3F682231A3C61310E1CE32DB931BBBAE43_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* EventHandler_1_tEFE51D141A816E328C23211083B6A5CDCAAF1BED_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ExceptionEventArgs_t1207BC0BED111D8BEA61607413C2A139F8A1DDC0_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Exception_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IDisposable_t099785737FC6A1E3699919A94109383715A8D807_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IEnumerable_1_t52B1AC8D9E5E1ED28DF6C46A37C9A1B00B394F9D_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IEnumerator_1_t2DC97C7D486BF9E077C2BC2E517E434F393AA76E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IEnumerator_t5956F3AFB7ECF1117E3BC5890E7FC7B7F7A04105_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Int32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Int64_t378EE0D608BD3107E77238E85F30D2BBD46981F3_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* InvalidOperationException_t10D3EE59AD28EC641ACEE05BCA4271A527E5ECAB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* OscBundleReceivedEventArgs_t1ABF2F51A974BCF1B4328DCA66A094C2D6AB6345_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* OscMessageReceivedEventArgs_t8E8CE6EC7E84AF0892F400AB363313C22B8C4E83_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* OscPacketReceivedEventArgs_t61CB29F943015645037B535D6348EA15E19C680B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Single_tE07797BA3C98D4CA9B5A19413C19A76688AB899E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ThreadStart_tA13019555BA3CB2B0128F0880760196BF790E687_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TransportType_t19FD2303B5B680C76D1B24D778D0959E9AE8198C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral41F9662AC67058AED0D7122A99991B3220ED038D;
IL2CPP_EXTERN_C String_t* _stringLiteral59D2C03D11B34581CD247E011280983E6284ED2D;
IL2CPP_EXTERN_C String_t* _stringLiteral6CB20796A7CD300175C3C97D9D0B31A65326CA4E;
IL2CPP_EXTERN_C String_t* _stringLiteral86BBAACC00198DBB3046818AD3FC2AA10AE48DE1;
IL2CPP_EXTERN_C String_t* _stringLiteralB952A8DB3269CA1A3FB83A3B517860948B30AF01;
IL2CPP_EXTERN_C const RuntimeMethod* EventHandler_1_Invoke_m9FBD0C6547BE3E0181C257B21FC575BF296A5205_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* EventHandler_1_Invoke_mC992C9DD6820DCE0E81AC4354254266855395E44_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* EventHandler_1_Invoke_mDAF40BCF69918DFB2E3A7C5006658EBD7B6DFA22_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* EventHandler_1_Invoke_mE2206F76F47AF2795139FCA29519AA990016BEC4_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* EventHandler_1__ctor_m8D618A691D600BE62ECACECD277A03C3EFD5B474_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* EventHandler_1__ctor_mA440F83BE7D36CF2D080BA620518CCD0B2114A06_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Add_m627ED3F7C50096BB8934F778CB980E79483BD2AE_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_AsReadOnly_m2A562BCF70602A773C266FE3B151E1A56D884F71_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Contains_m2EAD2DADA0478175052301E48FCE772ECD9A6F5F_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_m0F0E00088CF56FEACC9E32D8B7D91B93D91DAA3B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_m30C52A4F2828D86CA3FAB0B1B583948F4DA9F1F9_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* OscPacket_Append_TisOscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_m71375CEDD55045937DA18D10DE08B4FC26398809_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* OscPacket_Append_TisRuntimeObject_mC8350C70C82033B5A4E83A2F005E6D173918DEA6_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* OscPacket_ValueFromByteArray_TisByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726_m1A34F855D9CC53697284E7EFDBBCD4BC64E3E8EE_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* OscPacket_ValueFromByteArray_TisChar_tFF60D8E7E89A20BE2294A003734341BD1DF43E14_m4A612DEE0C33EEDBF5AEB0708E5E61CDA9D45F62_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* OscPacket_ValueFromByteArray_TisColor_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334_m2D0F95410365A923A816432EF1F027047CE65238_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* OscPacket_ValueFromByteArray_TisDouble_t42821932CB52DE2057E685D0E1AF3DE5033D2181_mCF0D171BA5AD93AF48B22E2341F024AD314EC82B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* OscPacket_ValueFromByteArray_TisInt32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046_m32A19AD88A6771691E46A055613812D325C93D8A_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* OscPacket_ValueFromByteArray_TisInt64_t378EE0D608BD3107E77238E85F30D2BBD46981F3_mC08348CB553E77F8AB350FEFA1FF2E8FFD6C9BFA_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* OscPacket_ValueFromByteArray_TisOscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_mE6B1E20C5F893E6DC5FBF2E61FB4C54DFF69E7CF_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* OscPacket_ValueFromByteArray_TisSingle_tE07797BA3C98D4CA9B5A19413C19A76688AB899E_mA63BCB726472D5DDB910066AC162C379EDC64645_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* OscPacket_ValueFromByteArray_TisString_t_m0AA6001643C0B3FAAE1B4558B9B77CD82411E198_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* OscServer_Start_m1044E6A9E06A238BF97E02C480569E848250789E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* OscServer__ctor_m498CAB23F18494FEADE8230BBF2977488AA38834_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* OscServer_mTcpServer_DataReceived_mF3226741BBCC4C27878F698FA408C98E5A970DC2_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* OscServer_mUdpServer_DataReceived_mA52B3AF0ABC91329EF251A4092268301E472E57B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TcpServer_Start_mD4EF9EFDD7F305349C3C8B52B63CE46A45920A36_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Utility_CopySubArray_TisByte_t0111FAB8B8685667EDDAF77683F0D8F86B659056_m34AF4999A31EB9E8E03253BAF85132FF9341AC35_RuntimeMethod_var;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;

struct ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726;
struct CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_tCB71CCBF2A7A99640A6F5D9EBA6DB1EB5DBE2441 
{
public:

public:
};


// System.Object


// System.Collections.Generic.List`1<System.Object>
struct List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5, ____items_1)); }
	inline ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* get__items_1() const { return ____items_1; }
	inline ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____items_1), (void*)value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____syncRoot_4), (void*)value);
	}
};

struct List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5_StaticFields, ____emptyArray_5)); }
	inline ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* get__emptyArray_5() const { return ____emptyArray_5; }
	inline ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(ObjectU5BU5D_tC1F4EE0DB0B7300255F5FD4AF64FE4C585CF5ADE* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____emptyArray_5), (void*)value);
	}
};


// System.Collections.Generic.List`1<System.String>
struct List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	StringU5BU5D_tACEBFEDE350025B554CD507C9AE8FFE49359549A* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject * ____syncRoot_4;

public:
	inline static int32_t get_offset_of__items_1() { return static_cast<int32_t>(offsetof(List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3, ____items_1)); }
	inline StringU5BU5D_tACEBFEDE350025B554CD507C9AE8FFE49359549A* get__items_1() const { return ____items_1; }
	inline StringU5BU5D_tACEBFEDE350025B554CD507C9AE8FFE49359549A** get_address_of__items_1() { return &____items_1; }
	inline void set__items_1(StringU5BU5D_tACEBFEDE350025B554CD507C9AE8FFE49359549A* value)
	{
		____items_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____items_1), (void*)value);
	}

	inline static int32_t get_offset_of__size_2() { return static_cast<int32_t>(offsetof(List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3, ____size_2)); }
	inline int32_t get__size_2() const { return ____size_2; }
	inline int32_t* get_address_of__size_2() { return &____size_2; }
	inline void set__size_2(int32_t value)
	{
		____size_2 = value;
	}

	inline static int32_t get_offset_of__version_3() { return static_cast<int32_t>(offsetof(List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3, ____version_3)); }
	inline int32_t get__version_3() const { return ____version_3; }
	inline int32_t* get_address_of__version_3() { return &____version_3; }
	inline void set__version_3(int32_t value)
	{
		____version_3 = value;
	}

	inline static int32_t get_offset_of__syncRoot_4() { return static_cast<int32_t>(offsetof(List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3, ____syncRoot_4)); }
	inline RuntimeObject * get__syncRoot_4() const { return ____syncRoot_4; }
	inline RuntimeObject ** get_address_of__syncRoot_4() { return &____syncRoot_4; }
	inline void set__syncRoot_4(RuntimeObject * value)
	{
		____syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____syncRoot_4), (void*)value);
	}
};

struct List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3_StaticFields
{
public:
	// T[] System.Collections.Generic.List`1::_emptyArray
	StringU5BU5D_tACEBFEDE350025B554CD507C9AE8FFE49359549A* ____emptyArray_5;

public:
	inline static int32_t get_offset_of__emptyArray_5() { return static_cast<int32_t>(offsetof(List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3_StaticFields, ____emptyArray_5)); }
	inline StringU5BU5D_tACEBFEDE350025B554CD507C9AE8FFE49359549A* get__emptyArray_5() const { return ____emptyArray_5; }
	inline StringU5BU5D_tACEBFEDE350025B554CD507C9AE8FFE49359549A** get_address_of__emptyArray_5() { return &____emptyArray_5; }
	inline void set__emptyArray_5(StringU5BU5D_tACEBFEDE350025B554CD507C9AE8FFE49359549A* value)
	{
		____emptyArray_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____emptyArray_5), (void*)value);
	}
};


// System.Collections.ObjectModel.ReadOnlyCollection`1<System.Object>
struct ReadOnlyCollection_1_t921D1901AD35062BE31FAEB0798A4B814F33A3C3  : public RuntimeObject
{
public:
	// System.Collections.Generic.IList`1<T> System.Collections.ObjectModel.ReadOnlyCollection`1::list
	RuntimeObject* ___list_0;
	// System.Object System.Collections.ObjectModel.ReadOnlyCollection`1::_syncRoot
	RuntimeObject * ____syncRoot_1;

public:
	inline static int32_t get_offset_of_list_0() { return static_cast<int32_t>(offsetof(ReadOnlyCollection_1_t921D1901AD35062BE31FAEB0798A4B814F33A3C3, ___list_0)); }
	inline RuntimeObject* get_list_0() const { return ___list_0; }
	inline RuntimeObject** get_address_of_list_0() { return &___list_0; }
	inline void set_list_0(RuntimeObject* value)
	{
		___list_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___list_0), (void*)value);
	}

	inline static int32_t get_offset_of__syncRoot_1() { return static_cast<int32_t>(offsetof(ReadOnlyCollection_1_t921D1901AD35062BE31FAEB0798A4B814F33A3C3, ____syncRoot_1)); }
	inline RuntimeObject * get__syncRoot_1() const { return ____syncRoot_1; }
	inline RuntimeObject ** get_address_of__syncRoot_1() { return &____syncRoot_1; }
	inline void set__syncRoot_1(RuntimeObject * value)
	{
		____syncRoot_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____syncRoot_1), (void*)value);
	}
};


// <PrivateImplementationDetails>{9E102208-4C03-43BC-98DC-02AB1B7B4A10}
struct U3CPrivateImplementationDetailsU3EU7B9E102208U2D4C03U2D43BCU2D98DCU2D02AB1B7B4A10U7D_t5CB31B0A2CAD4F50917F2AEA9EC832662602AFA6  : public RuntimeObject
{
public:

public:
};

struct U3CPrivateImplementationDetailsU3EU7B9E102208U2D4C03U2D43BCU2D98DCU2D02AB1B7B4A10U7D_t5CB31B0A2CAD4F50917F2AEA9EC832662602AFA6_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> <PrivateImplementationDetails>{9E102208-4C03-43BC-98DC-02AB1B7B4A10}::$$method0x600006d-1
	Dictionary_2_tC94E9875910491F8130C2DC8B11E4D1548A55162 * ___U24U24method0x600006dU2D1_0;

public:
	inline static int32_t get_offset_of_U24U24method0x600006dU2D1_0() { return static_cast<int32_t>(offsetof(U3CPrivateImplementationDetailsU3EU7B9E102208U2D4C03U2D43BCU2D98DCU2D02AB1B7B4A10U7D_t5CB31B0A2CAD4F50917F2AEA9EC832662602AFA6_StaticFields, ___U24U24method0x600006dU2D1_0)); }
	inline Dictionary_2_tC94E9875910491F8130C2DC8B11E4D1548A55162 * get_U24U24method0x600006dU2D1_0() const { return ___U24U24method0x600006dU2D1_0; }
	inline Dictionary_2_tC94E9875910491F8130C2DC8B11E4D1548A55162 ** get_address_of_U24U24method0x600006dU2D1_0() { return &___U24U24method0x600006dU2D1_0; }
	inline void set_U24U24method0x600006dU2D1_0(Dictionary_2_tC94E9875910491F8130C2DC8B11E4D1548A55162 * value)
	{
		___U24U24method0x600006dU2D1_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___U24U24method0x600006dU2D1_0), (void*)value);
	}
};

struct Il2CppArrayBounds;

// System.Array


// System.BitConverter
struct BitConverter_t8DCBA24B909F1B221372AF2B37C76DCF614BA654  : public RuntimeObject
{
public:

public:
};

struct BitConverter_t8DCBA24B909F1B221372AF2B37C76DCF614BA654_StaticFields
{
public:
	// System.Boolean System.BitConverter::IsLittleEndian
	bool ___IsLittleEndian_0;

public:
	inline static int32_t get_offset_of_IsLittleEndian_0() { return static_cast<int32_t>(offsetof(BitConverter_t8DCBA24B909F1B221372AF2B37C76DCF614BA654_StaticFields, ___IsLittleEndian_0)); }
	inline bool get_IsLittleEndian_0() const { return ___IsLittleEndian_0; }
	inline bool* get_address_of_IsLittleEndian_0() { return &___IsLittleEndian_0; }
	inline void set_IsLittleEndian_0(bool value)
	{
		___IsLittleEndian_0 = value;
	}
};


// System.Runtime.ConstrainedExecution.CriticalFinalizerObject
struct CriticalFinalizerObject_tA3367C832FFE7434EB3C15C7136AF25524150997  : public RuntimeObject
{
public:

public:
};


// System.Net.EndPoint
struct EndPoint_t18D4AE8D03090A2B262136E59F95CE61418C34DA  : public RuntimeObject
{
public:

public:
};


// System.EventArgs
struct EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA  : public RuntimeObject
{
public:

public:
};

struct EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA_StaticFields
{
public:
	// System.EventArgs System.EventArgs::Empty
	EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA * ___Empty_0;

public:
	inline static int32_t get_offset_of_Empty_0() { return static_cast<int32_t>(offsetof(EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA_StaticFields, ___Empty_0)); }
	inline EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA * get_Empty_0() const { return ___Empty_0; }
	inline EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA ** get_address_of_Empty_0() { return &___Empty_0; }
	inline void set_Empty_0(EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA * value)
	{
		___Empty_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Empty_0), (void*)value);
	}
};


// Bespoke.Common.Net.IPServer
struct IPServer_tBEF36D7D3CD1DEBACE97ACE01D198E4EA25D3C06  : public RuntimeObject
{
public:

public:
};


// Bespoke.Common.Osc.OscClient
struct OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591  : public RuntimeObject
{
public:
	// System.Net.IPAddress Bespoke.Common.Osc.OscClient::mServerIPAddress
	IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___mServerIPAddress_0;
	// System.Int32 Bespoke.Common.Osc.OscClient::mServerPort
	int32_t ___mServerPort_1;
	// System.Net.Sockets.TcpClient Bespoke.Common.Osc.OscClient::mClient
	TcpClient_t0EEB05EA031F6AFD93D46116F5E33A9C4E3350EE * ___mClient_2;
	// Bespoke.Common.Net.TcpConnection Bespoke.Common.Osc.OscClient::mTcpConnection
	TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129 * ___mTcpConnection_3;

public:
	inline static int32_t get_offset_of_mServerIPAddress_0() { return static_cast<int32_t>(offsetof(OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591, ___mServerIPAddress_0)); }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * get_mServerIPAddress_0() const { return ___mServerIPAddress_0; }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE ** get_address_of_mServerIPAddress_0() { return &___mServerIPAddress_0; }
	inline void set_mServerIPAddress_0(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * value)
	{
		___mServerIPAddress_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mServerIPAddress_0), (void*)value);
	}

	inline static int32_t get_offset_of_mServerPort_1() { return static_cast<int32_t>(offsetof(OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591, ___mServerPort_1)); }
	inline int32_t get_mServerPort_1() const { return ___mServerPort_1; }
	inline int32_t* get_address_of_mServerPort_1() { return &___mServerPort_1; }
	inline void set_mServerPort_1(int32_t value)
	{
		___mServerPort_1 = value;
	}

	inline static int32_t get_offset_of_mClient_2() { return static_cast<int32_t>(offsetof(OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591, ___mClient_2)); }
	inline TcpClient_t0EEB05EA031F6AFD93D46116F5E33A9C4E3350EE * get_mClient_2() const { return ___mClient_2; }
	inline TcpClient_t0EEB05EA031F6AFD93D46116F5E33A9C4E3350EE ** get_address_of_mClient_2() { return &___mClient_2; }
	inline void set_mClient_2(TcpClient_t0EEB05EA031F6AFD93D46116F5E33A9C4E3350EE * value)
	{
		___mClient_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mClient_2), (void*)value);
	}

	inline static int32_t get_offset_of_mTcpConnection_3() { return static_cast<int32_t>(offsetof(OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591, ___mTcpConnection_3)); }
	inline TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129 * get_mTcpConnection_3() const { return ___mTcpConnection_3; }
	inline TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129 ** get_address_of_mTcpConnection_3() { return &___mTcpConnection_3; }
	inline void set_mTcpConnection_3(TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129 * value)
	{
		___mTcpConnection_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mTcpConnection_3), (void*)value);
	}
};


// Bespoke.Common.Osc.OscPacket
struct OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5  : public RuntimeObject
{
public:
	// System.Net.IPEndPoint Bespoke.Common.Osc.OscPacket::mSourceEndPoint
	IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___mSourceEndPoint_1;
	// System.String Bespoke.Common.Osc.OscPacket::mAddress
	String_t* ___mAddress_2;
	// System.Collections.Generic.List`1<System.Object> Bespoke.Common.Osc.OscPacket::mData
	List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * ___mData_3;
	// Bespoke.Common.Osc.OscClient Bespoke.Common.Osc.OscPacket::mClient
	OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591 * ___mClient_4;

public:
	inline static int32_t get_offset_of_mSourceEndPoint_1() { return static_cast<int32_t>(offsetof(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5, ___mSourceEndPoint_1)); }
	inline IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * get_mSourceEndPoint_1() const { return ___mSourceEndPoint_1; }
	inline IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E ** get_address_of_mSourceEndPoint_1() { return &___mSourceEndPoint_1; }
	inline void set_mSourceEndPoint_1(IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * value)
	{
		___mSourceEndPoint_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mSourceEndPoint_1), (void*)value);
	}

	inline static int32_t get_offset_of_mAddress_2() { return static_cast<int32_t>(offsetof(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5, ___mAddress_2)); }
	inline String_t* get_mAddress_2() const { return ___mAddress_2; }
	inline String_t** get_address_of_mAddress_2() { return &___mAddress_2; }
	inline void set_mAddress_2(String_t* value)
	{
		___mAddress_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mAddress_2), (void*)value);
	}

	inline static int32_t get_offset_of_mData_3() { return static_cast<int32_t>(offsetof(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5, ___mData_3)); }
	inline List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * get_mData_3() const { return ___mData_3; }
	inline List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 ** get_address_of_mData_3() { return &___mData_3; }
	inline void set_mData_3(List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * value)
	{
		___mData_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mData_3), (void*)value);
	}

	inline static int32_t get_offset_of_mClient_4() { return static_cast<int32_t>(offsetof(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5, ___mClient_4)); }
	inline OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591 * get_mClient_4() const { return ___mClient_4; }
	inline OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591 ** get_address_of_mClient_4() { return &___mClient_4; }
	inline void set_mClient_4(OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591 * value)
	{
		___mClient_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mClient_4), (void*)value);
	}
};

struct OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_StaticFields
{
public:
	// System.Boolean Bespoke.Common.Osc.OscPacket::sLittleEndianByteOrder
	bool ___sLittleEndianByteOrder_0;
	// System.Net.Sockets.UdpClient Bespoke.Common.Osc.OscPacket::sUdpClient
	UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920 * ___sUdpClient_5;

public:
	inline static int32_t get_offset_of_sLittleEndianByteOrder_0() { return static_cast<int32_t>(offsetof(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_StaticFields, ___sLittleEndianByteOrder_0)); }
	inline bool get_sLittleEndianByteOrder_0() const { return ___sLittleEndianByteOrder_0; }
	inline bool* get_address_of_sLittleEndianByteOrder_0() { return &___sLittleEndianByteOrder_0; }
	inline void set_sLittleEndianByteOrder_0(bool value)
	{
		___sLittleEndianByteOrder_0 = value;
	}

	inline static int32_t get_offset_of_sUdpClient_5() { return static_cast<int32_t>(offsetof(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_StaticFields, ___sUdpClient_5)); }
	inline UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920 * get_sUdpClient_5() const { return ___sUdpClient_5; }
	inline UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920 ** get_address_of_sUdpClient_5() { return &___sUdpClient_5; }
	inline void set_sUdpClient_5(UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920 * value)
	{
		___sUdpClient_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___sUdpClient_5), (void*)value);
	}
};


// System.String
struct String_t  : public RuntimeObject
{
public:
	// System.Int32 System.String::m_stringLength
	int32_t ___m_stringLength_0;
	// System.Char System.String::m_firstChar
	Il2CppChar ___m_firstChar_1;

public:
	inline static int32_t get_offset_of_m_stringLength_0() { return static_cast<int32_t>(offsetof(String_t, ___m_stringLength_0)); }
	inline int32_t get_m_stringLength_0() const { return ___m_stringLength_0; }
	inline int32_t* get_address_of_m_stringLength_0() { return &___m_stringLength_0; }
	inline void set_m_stringLength_0(int32_t value)
	{
		___m_stringLength_0 = value;
	}

	inline static int32_t get_offset_of_m_firstChar_1() { return static_cast<int32_t>(offsetof(String_t, ___m_firstChar_1)); }
	inline Il2CppChar get_m_firstChar_1() const { return ___m_firstChar_1; }
	inline Il2CppChar* get_address_of_m_firstChar_1() { return &___m_firstChar_1; }
	inline void set_m_firstChar_1(Il2CppChar value)
	{
		___m_firstChar_1 = value;
	}
};

struct String_t_StaticFields
{
public:
	// System.String System.String::Empty
	String_t* ___Empty_5;

public:
	inline static int32_t get_offset_of_Empty_5() { return static_cast<int32_t>(offsetof(String_t_StaticFields, ___Empty_5)); }
	inline String_t* get_Empty_5() const { return ___Empty_5; }
	inline String_t** get_address_of_Empty_5() { return &___Empty_5; }
	inline void set_Empty_5(String_t* value)
	{
		___Empty_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Empty_5), (void*)value);
	}
};


// System.ValueType
struct ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52  : public RuntimeObject
{
public:

public:
};

// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52_marshaled_com
{
};

// System.Boolean
struct Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37 
{
public:
	// System.Boolean System.Boolean::m_value
	bool ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37, ___m_value_0)); }
	inline bool get_m_value_0() const { return ___m_value_0; }
	inline bool* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(bool value)
	{
		___m_value_0 = value;
	}
};

struct Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_StaticFields
{
public:
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;

public:
	inline static int32_t get_offset_of_TrueString_5() { return static_cast<int32_t>(offsetof(Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_StaticFields, ___TrueString_5)); }
	inline String_t* get_TrueString_5() const { return ___TrueString_5; }
	inline String_t** get_address_of_TrueString_5() { return &___TrueString_5; }
	inline void set_TrueString_5(String_t* value)
	{
		___TrueString_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___TrueString_5), (void*)value);
	}

	inline static int32_t get_offset_of_FalseString_6() { return static_cast<int32_t>(offsetof(Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_StaticFields, ___FalseString_6)); }
	inline String_t* get_FalseString_6() const { return ___FalseString_6; }
	inline String_t** get_address_of_FalseString_6() { return &___FalseString_6; }
	inline void set_FalseString_6(String_t* value)
	{
		___FalseString_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___FalseString_6), (void*)value);
	}
};


// System.Byte
struct Byte_t0111FAB8B8685667EDDAF77683F0D8F86B659056 
{
public:
	// System.Byte System.Byte::m_value
	uint8_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Byte_t0111FAB8B8685667EDDAF77683F0D8F86B659056, ___m_value_0)); }
	inline uint8_t get_m_value_0() const { return ___m_value_0; }
	inline uint8_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(uint8_t value)
	{
		___m_value_0 = value;
	}
};


// System.Char
struct Char_tFF60D8E7E89A20BE2294A003734341BD1DF43E14 
{
public:
	// System.Char System.Char::m_value
	Il2CppChar ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Char_tFF60D8E7E89A20BE2294A003734341BD1DF43E14, ___m_value_0)); }
	inline Il2CppChar get_m_value_0() const { return ___m_value_0; }
	inline Il2CppChar* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(Il2CppChar value)
	{
		___m_value_0 = value;
	}
};

struct Char_tFF60D8E7E89A20BE2294A003734341BD1DF43E14_StaticFields
{
public:
	// System.Byte[] System.Char::categoryForLatin1
	ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___categoryForLatin1_3;

public:
	inline static int32_t get_offset_of_categoryForLatin1_3() { return static_cast<int32_t>(offsetof(Char_tFF60D8E7E89A20BE2294A003734341BD1DF43E14_StaticFields, ___categoryForLatin1_3)); }
	inline ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* get_categoryForLatin1_3() const { return ___categoryForLatin1_3; }
	inline ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726** get_address_of_categoryForLatin1_3() { return &___categoryForLatin1_3; }
	inline void set_categoryForLatin1_3(ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* value)
	{
		___categoryForLatin1_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___categoryForLatin1_3), (void*)value);
	}
};


// System.Drawing.Color
struct Color_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334 
{
public:
	// System.Int64 System.Drawing.Color::value
	int64_t ___value_0;
	// System.Int16 System.Drawing.Color::state
	int16_t ___state_1;
	// System.Int16 System.Drawing.Color::knownColor
	int16_t ___knownColor_2;
	// System.String System.Drawing.Color::name
	String_t* ___name_3;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(Color_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334, ___value_0)); }
	inline int64_t get_value_0() const { return ___value_0; }
	inline int64_t* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(int64_t value)
	{
		___value_0 = value;
	}

	inline static int32_t get_offset_of_state_1() { return static_cast<int32_t>(offsetof(Color_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334, ___state_1)); }
	inline int16_t get_state_1() const { return ___state_1; }
	inline int16_t* get_address_of_state_1() { return &___state_1; }
	inline void set_state_1(int16_t value)
	{
		___state_1 = value;
	}

	inline static int32_t get_offset_of_knownColor_2() { return static_cast<int32_t>(offsetof(Color_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334, ___knownColor_2)); }
	inline int16_t get_knownColor_2() const { return ___knownColor_2; }
	inline int16_t* get_address_of_knownColor_2() { return &___knownColor_2; }
	inline void set_knownColor_2(int16_t value)
	{
		___knownColor_2 = value;
	}

	inline static int32_t get_offset_of_name_3() { return static_cast<int32_t>(offsetof(Color_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334, ___name_3)); }
	inline String_t* get_name_3() const { return ___name_3; }
	inline String_t** get_address_of_name_3() { return &___name_3; }
	inline void set_name_3(String_t* value)
	{
		___name_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___name_3), (void*)value);
	}
};

// Native definition for P/Invoke marshalling of System.Drawing.Color
struct Color_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334_marshaled_pinvoke
{
	int64_t ___value_0;
	int16_t ___state_1;
	int16_t ___knownColor_2;
	char* ___name_3;
};
// Native definition for COM marshalling of System.Drawing.Color
struct Color_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334_marshaled_com
{
	int64_t ___value_0;
	int16_t ___state_1;
	int16_t ___knownColor_2;
	Il2CppChar* ___name_3;
};

// System.DateTime
struct DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 
{
public:
	// System.UInt64 System.DateTime::dateData
	uint64_t ___dateData_44;

public:
	inline static int32_t get_offset_of_dateData_44() { return static_cast<int32_t>(offsetof(DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405, ___dateData_44)); }
	inline uint64_t get_dateData_44() const { return ___dateData_44; }
	inline uint64_t* get_address_of_dateData_44() { return &___dateData_44; }
	inline void set_dateData_44(uint64_t value)
	{
		___dateData_44 = value;
	}
};

struct DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405_StaticFields
{
public:
	// System.Int32[] System.DateTime::DaysToMonth365
	Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* ___DaysToMonth365_29;
	// System.Int32[] System.DateTime::DaysToMonth366
	Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* ___DaysToMonth366_30;
	// System.DateTime System.DateTime::MinValue
	DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  ___MinValue_31;
	// System.DateTime System.DateTime::MaxValue
	DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  ___MaxValue_32;

public:
	inline static int32_t get_offset_of_DaysToMonth365_29() { return static_cast<int32_t>(offsetof(DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405_StaticFields, ___DaysToMonth365_29)); }
	inline Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* get_DaysToMonth365_29() const { return ___DaysToMonth365_29; }
	inline Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32** get_address_of_DaysToMonth365_29() { return &___DaysToMonth365_29; }
	inline void set_DaysToMonth365_29(Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* value)
	{
		___DaysToMonth365_29 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___DaysToMonth365_29), (void*)value);
	}

	inline static int32_t get_offset_of_DaysToMonth366_30() { return static_cast<int32_t>(offsetof(DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405_StaticFields, ___DaysToMonth366_30)); }
	inline Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* get_DaysToMonth366_30() const { return ___DaysToMonth366_30; }
	inline Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32** get_address_of_DaysToMonth366_30() { return &___DaysToMonth366_30; }
	inline void set_DaysToMonth366_30(Int32U5BU5D_t70F1BDC14B1786481B176D6139A5E3B87DC54C32* value)
	{
		___DaysToMonth366_30 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___DaysToMonth366_30), (void*)value);
	}

	inline static int32_t get_offset_of_MinValue_31() { return static_cast<int32_t>(offsetof(DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405_StaticFields, ___MinValue_31)); }
	inline DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  get_MinValue_31() const { return ___MinValue_31; }
	inline DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 * get_address_of_MinValue_31() { return &___MinValue_31; }
	inline void set_MinValue_31(DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  value)
	{
		___MinValue_31 = value;
	}

	inline static int32_t get_offset_of_MaxValue_32() { return static_cast<int32_t>(offsetof(DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405_StaticFields, ___MaxValue_32)); }
	inline DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  get_MaxValue_32() const { return ___MaxValue_32; }
	inline DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 * get_address_of_MaxValue_32() { return &___MaxValue_32; }
	inline void set_MaxValue_32(DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  value)
	{
		___MaxValue_32 = value;
	}
};


// System.Double
struct Double_t42821932CB52DE2057E685D0E1AF3DE5033D2181 
{
public:
	// System.Double System.Double::m_value
	double ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Double_t42821932CB52DE2057E685D0E1AF3DE5033D2181, ___m_value_0)); }
	inline double get_m_value_0() const { return ___m_value_0; }
	inline double* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(double value)
	{
		___m_value_0 = value;
	}
};

struct Double_t42821932CB52DE2057E685D0E1AF3DE5033D2181_StaticFields
{
public:
	// System.Double System.Double::NegativeZero
	double ___NegativeZero_7;

public:
	inline static int32_t get_offset_of_NegativeZero_7() { return static_cast<int32_t>(offsetof(Double_t42821932CB52DE2057E685D0E1AF3DE5033D2181_StaticFields, ___NegativeZero_7)); }
	inline double get_NegativeZero_7() const { return ___NegativeZero_7; }
	inline double* get_address_of_NegativeZero_7() { return &___NegativeZero_7; }
	inline void set_NegativeZero_7(double value)
	{
		___NegativeZero_7 = value;
	}
};


// System.Enum
struct Enum_t23B90B40F60E677A8025267341651C94AE079CDA  : public ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52
{
public:

public:
};

struct Enum_t23B90B40F60E677A8025267341651C94AE079CDA_StaticFields
{
public:
	// System.Char[] System.Enum::enumSeperatorCharArray
	CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34* ___enumSeperatorCharArray_0;

public:
	inline static int32_t get_offset_of_enumSeperatorCharArray_0() { return static_cast<int32_t>(offsetof(Enum_t23B90B40F60E677A8025267341651C94AE079CDA_StaticFields, ___enumSeperatorCharArray_0)); }
	inline CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34* get_enumSeperatorCharArray_0() const { return ___enumSeperatorCharArray_0; }
	inline CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34** get_address_of_enumSeperatorCharArray_0() { return &___enumSeperatorCharArray_0; }
	inline void set_enumSeperatorCharArray_0(CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34* value)
	{
		___enumSeperatorCharArray_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___enumSeperatorCharArray_0), (void*)value);
	}
};

// Native definition for P/Invoke marshalling of System.Enum
struct Enum_t23B90B40F60E677A8025267341651C94AE079CDA_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.Enum
struct Enum_t23B90B40F60E677A8025267341651C94AE079CDA_marshaled_com
{
};

// Bespoke.Common.ExceptionEventArgs
struct ExceptionEventArgs_t1207BC0BED111D8BEA61607413C2A139F8A1DDC0  : public EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA
{
public:
	// System.Exception Bespoke.Common.ExceptionEventArgs::mException
	Exception_t * ___mException_1;

public:
	inline static int32_t get_offset_of_mException_1() { return static_cast<int32_t>(offsetof(ExceptionEventArgs_t1207BC0BED111D8BEA61607413C2A139F8A1DDC0, ___mException_1)); }
	inline Exception_t * get_mException_1() const { return ___mException_1; }
	inline Exception_t ** get_address_of_mException_1() { return &___mException_1; }
	inline void set_mException_1(Exception_t * value)
	{
		___mException_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mException_1), (void*)value);
	}
};


// System.Net.IPEndPoint
struct IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E  : public EndPoint_t18D4AE8D03090A2B262136E59F95CE61418C34DA
{
public:
	// System.Net.IPAddress System.Net.IPEndPoint::m_Address
	IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___m_Address_2;
	// System.Int32 System.Net.IPEndPoint::m_Port
	int32_t ___m_Port_3;

public:
	inline static int32_t get_offset_of_m_Address_2() { return static_cast<int32_t>(offsetof(IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E, ___m_Address_2)); }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * get_m_Address_2() const { return ___m_Address_2; }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE ** get_address_of_m_Address_2() { return &___m_Address_2; }
	inline void set_m_Address_2(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * value)
	{
		___m_Address_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Address_2), (void*)value);
	}

	inline static int32_t get_offset_of_m_Port_3() { return static_cast<int32_t>(offsetof(IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E, ___m_Port_3)); }
	inline int32_t get_m_Port_3() const { return ___m_Port_3; }
	inline int32_t* get_address_of_m_Port_3() { return &___m_Port_3; }
	inline void set_m_Port_3(int32_t value)
	{
		___m_Port_3 = value;
	}
};

struct IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E_StaticFields
{
public:
	// System.Net.IPEndPoint System.Net.IPEndPoint::Any
	IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___Any_5;
	// System.Net.IPEndPoint System.Net.IPEndPoint::IPv6Any
	IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___IPv6Any_6;

public:
	inline static int32_t get_offset_of_Any_5() { return static_cast<int32_t>(offsetof(IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E_StaticFields, ___Any_5)); }
	inline IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * get_Any_5() const { return ___Any_5; }
	inline IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E ** get_address_of_Any_5() { return &___Any_5; }
	inline void set_Any_5(IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * value)
	{
		___Any_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Any_5), (void*)value);
	}

	inline static int32_t get_offset_of_IPv6Any_6() { return static_cast<int32_t>(offsetof(IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E_StaticFields, ___IPv6Any_6)); }
	inline IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * get_IPv6Any_6() const { return ___IPv6Any_6; }
	inline IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E ** get_address_of_IPv6Any_6() { return &___IPv6Any_6; }
	inline void set_IPv6Any_6(IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * value)
	{
		___IPv6Any_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___IPv6Any_6), (void*)value);
	}
};


// System.Int32
struct Int32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046 
{
public:
	// System.Int32 System.Int32::m_value
	int32_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Int32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046, ___m_value_0)); }
	inline int32_t get_m_value_0() const { return ___m_value_0; }
	inline int32_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(int32_t value)
	{
		___m_value_0 = value;
	}
};


// System.Int64
struct Int64_t378EE0D608BD3107E77238E85F30D2BBD46981F3 
{
public:
	// System.Int64 System.Int64::m_value
	int64_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Int64_t378EE0D608BD3107E77238E85F30D2BBD46981F3, ___m_value_0)); }
	inline int64_t get_m_value_0() const { return ___m_value_0; }
	inline int64_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(int64_t value)
	{
		___m_value_0 = value;
	}
};


// System.IntPtr
struct IntPtr_t 
{
public:
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(IntPtr_t, ___m_value_0)); }
	inline void* get_m_value_0() const { return ___m_value_0; }
	inline void** get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(void* value)
	{
		___m_value_0 = value;
	}
};

struct IntPtr_t_StaticFields
{
public:
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;

public:
	inline static int32_t get_offset_of_Zero_1() { return static_cast<int32_t>(offsetof(IntPtr_t_StaticFields, ___Zero_1)); }
	inline intptr_t get_Zero_1() const { return ___Zero_1; }
	inline intptr_t* get_address_of_Zero_1() { return &___Zero_1; }
	inline void set_Zero_1(intptr_t value)
	{
		___Zero_1 = value;
	}
};


// Bespoke.Common.Osc.OscBundle
struct OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41  : public OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5
{
public:
	// Bespoke.Common.Osc.OscTimeTag Bespoke.Common.Osc.OscBundle::mTimeStamp
	OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * ___mTimeStamp_7;

public:
	inline static int32_t get_offset_of_mTimeStamp_7() { return static_cast<int32_t>(offsetof(OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41, ___mTimeStamp_7)); }
	inline OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * get_mTimeStamp_7() const { return ___mTimeStamp_7; }
	inline OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB ** get_address_of_mTimeStamp_7() { return &___mTimeStamp_7; }
	inline void set_mTimeStamp_7(OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * value)
	{
		___mTimeStamp_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mTimeStamp_7), (void*)value);
	}
};


// Bespoke.Common.Osc.OscBundleReceivedEventArgs
struct OscBundleReceivedEventArgs_t1ABF2F51A974BCF1B4328DCA66A094C2D6AB6345  : public EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA
{
public:
	// Bespoke.Common.Osc.OscBundle Bespoke.Common.Osc.OscBundleReceivedEventArgs::mBundle
	OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * ___mBundle_1;

public:
	inline static int32_t get_offset_of_mBundle_1() { return static_cast<int32_t>(offsetof(OscBundleReceivedEventArgs_t1ABF2F51A974BCF1B4328DCA66A094C2D6AB6345, ___mBundle_1)); }
	inline OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * get_mBundle_1() const { return ___mBundle_1; }
	inline OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 ** get_address_of_mBundle_1() { return &___mBundle_1; }
	inline void set_mBundle_1(OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * value)
	{
		___mBundle_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mBundle_1), (void*)value);
	}
};


// Bespoke.Common.Osc.OscMessage
struct OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2  : public OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5
{
public:
	// System.String Bespoke.Common.Osc.OscMessage::mTypeTag
	String_t* ___mTypeTag_22;

public:
	inline static int32_t get_offset_of_mTypeTag_22() { return static_cast<int32_t>(offsetof(OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2, ___mTypeTag_22)); }
	inline String_t* get_mTypeTag_22() const { return ___mTypeTag_22; }
	inline String_t** get_address_of_mTypeTag_22() { return &___mTypeTag_22; }
	inline void set_mTypeTag_22(String_t* value)
	{
		___mTypeTag_22 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mTypeTag_22), (void*)value);
	}
};


// Bespoke.Common.Osc.OscMessageReceivedEventArgs
struct OscMessageReceivedEventArgs_t8E8CE6EC7E84AF0892F400AB363313C22B8C4E83  : public EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA
{
public:
	// Bespoke.Common.Osc.OscMessage Bespoke.Common.Osc.OscMessageReceivedEventArgs::mMessage
	OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * ___mMessage_1;

public:
	inline static int32_t get_offset_of_mMessage_1() { return static_cast<int32_t>(offsetof(OscMessageReceivedEventArgs_t8E8CE6EC7E84AF0892F400AB363313C22B8C4E83, ___mMessage_1)); }
	inline OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * get_mMessage_1() const { return ___mMessage_1; }
	inline OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 ** get_address_of_mMessage_1() { return &___mMessage_1; }
	inline void set_mMessage_1(OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * value)
	{
		___mMessage_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mMessage_1), (void*)value);
	}
};


// Bespoke.Common.Osc.OscPacketReceivedEventArgs
struct OscPacketReceivedEventArgs_t61CB29F943015645037B535D6348EA15E19C680B  : public EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA
{
public:
	// Bespoke.Common.Osc.OscPacket Bespoke.Common.Osc.OscPacketReceivedEventArgs::mPacket
	OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * ___mPacket_1;

public:
	inline static int32_t get_offset_of_mPacket_1() { return static_cast<int32_t>(offsetof(OscPacketReceivedEventArgs_t61CB29F943015645037B535D6348EA15E19C680B, ___mPacket_1)); }
	inline OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * get_mPacket_1() const { return ___mPacket_1; }
	inline OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 ** get_address_of_mPacket_1() { return &___mPacket_1; }
	inline void set_mPacket_1(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * value)
	{
		___mPacket_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mPacket_1), (void*)value);
	}
};


// System.Single
struct Single_tE07797BA3C98D4CA9B5A19413C19A76688AB899E 
{
public:
	// System.Single System.Single::m_value
	float ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Single_tE07797BA3C98D4CA9B5A19413C19A76688AB899E, ___m_value_0)); }
	inline float get_m_value_0() const { return ___m_value_0; }
	inline float* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(float value)
	{
		___m_value_0 = value;
	}
};


// Bespoke.Common.Net.TcpDataReceivedEventArgs
struct TcpDataReceivedEventArgs_t2A59DD027A324B15BAE90E0AC00122E825EDF4B3  : public EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA
{
public:
	// Bespoke.Common.Net.TcpConnection Bespoke.Common.Net.TcpDataReceivedEventArgs::mConnection
	TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129 * ___mConnection_1;
	// System.Byte[] Bespoke.Common.Net.TcpDataReceivedEventArgs::mData
	ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___mData_2;

public:
	inline static int32_t get_offset_of_mConnection_1() { return static_cast<int32_t>(offsetof(TcpDataReceivedEventArgs_t2A59DD027A324B15BAE90E0AC00122E825EDF4B3, ___mConnection_1)); }
	inline TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129 * get_mConnection_1() const { return ___mConnection_1; }
	inline TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129 ** get_address_of_mConnection_1() { return &___mConnection_1; }
	inline void set_mConnection_1(TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129 * value)
	{
		___mConnection_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mConnection_1), (void*)value);
	}

	inline static int32_t get_offset_of_mData_2() { return static_cast<int32_t>(offsetof(TcpDataReceivedEventArgs_t2A59DD027A324B15BAE90E0AC00122E825EDF4B3, ___mData_2)); }
	inline ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* get_mData_2() const { return ___mData_2; }
	inline ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726** get_address_of_mData_2() { return &___mData_2; }
	inline void set_mData_2(ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* value)
	{
		___mData_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mData_2), (void*)value);
	}
};


// System.Threading.Thread
struct Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414  : public CriticalFinalizerObject_tA3367C832FFE7434EB3C15C7136AF25524150997
{
public:
	// System.Threading.InternalThread System.Threading.Thread::internal_thread
	InternalThread_t12B78B27503AE19E9122E212419A66843BF746EB * ___internal_thread_6;
	// System.Object System.Threading.Thread::m_ThreadStartArg
	RuntimeObject * ___m_ThreadStartArg_7;
	// System.Object System.Threading.Thread::pending_exception
	RuntimeObject * ___pending_exception_8;
	// System.Security.Principal.IPrincipal System.Threading.Thread::principal
	RuntimeObject* ___principal_9;
	// System.Int32 System.Threading.Thread::principal_version
	int32_t ___principal_version_10;
	// System.MulticastDelegate System.Threading.Thread::m_Delegate
	MulticastDelegate_t * ___m_Delegate_12;
	// System.Threading.ExecutionContext System.Threading.Thread::m_ExecutionContext
	ExecutionContext_t16AC73BB21FEEEAD34A017877AC18DD8BB836414 * ___m_ExecutionContext_13;
	// System.Boolean System.Threading.Thread::m_ExecutionContextBelongsToOuterScope
	bool ___m_ExecutionContextBelongsToOuterScope_14;

public:
	inline static int32_t get_offset_of_internal_thread_6() { return static_cast<int32_t>(offsetof(Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414, ___internal_thread_6)); }
	inline InternalThread_t12B78B27503AE19E9122E212419A66843BF746EB * get_internal_thread_6() const { return ___internal_thread_6; }
	inline InternalThread_t12B78B27503AE19E9122E212419A66843BF746EB ** get_address_of_internal_thread_6() { return &___internal_thread_6; }
	inline void set_internal_thread_6(InternalThread_t12B78B27503AE19E9122E212419A66843BF746EB * value)
	{
		___internal_thread_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___internal_thread_6), (void*)value);
	}

	inline static int32_t get_offset_of_m_ThreadStartArg_7() { return static_cast<int32_t>(offsetof(Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414, ___m_ThreadStartArg_7)); }
	inline RuntimeObject * get_m_ThreadStartArg_7() const { return ___m_ThreadStartArg_7; }
	inline RuntimeObject ** get_address_of_m_ThreadStartArg_7() { return &___m_ThreadStartArg_7; }
	inline void set_m_ThreadStartArg_7(RuntimeObject * value)
	{
		___m_ThreadStartArg_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_ThreadStartArg_7), (void*)value);
	}

	inline static int32_t get_offset_of_pending_exception_8() { return static_cast<int32_t>(offsetof(Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414, ___pending_exception_8)); }
	inline RuntimeObject * get_pending_exception_8() const { return ___pending_exception_8; }
	inline RuntimeObject ** get_address_of_pending_exception_8() { return &___pending_exception_8; }
	inline void set_pending_exception_8(RuntimeObject * value)
	{
		___pending_exception_8 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___pending_exception_8), (void*)value);
	}

	inline static int32_t get_offset_of_principal_9() { return static_cast<int32_t>(offsetof(Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414, ___principal_9)); }
	inline RuntimeObject* get_principal_9() const { return ___principal_9; }
	inline RuntimeObject** get_address_of_principal_9() { return &___principal_9; }
	inline void set_principal_9(RuntimeObject* value)
	{
		___principal_9 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___principal_9), (void*)value);
	}

	inline static int32_t get_offset_of_principal_version_10() { return static_cast<int32_t>(offsetof(Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414, ___principal_version_10)); }
	inline int32_t get_principal_version_10() const { return ___principal_version_10; }
	inline int32_t* get_address_of_principal_version_10() { return &___principal_version_10; }
	inline void set_principal_version_10(int32_t value)
	{
		___principal_version_10 = value;
	}

	inline static int32_t get_offset_of_m_Delegate_12() { return static_cast<int32_t>(offsetof(Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414, ___m_Delegate_12)); }
	inline MulticastDelegate_t * get_m_Delegate_12() const { return ___m_Delegate_12; }
	inline MulticastDelegate_t ** get_address_of_m_Delegate_12() { return &___m_Delegate_12; }
	inline void set_m_Delegate_12(MulticastDelegate_t * value)
	{
		___m_Delegate_12 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Delegate_12), (void*)value);
	}

	inline static int32_t get_offset_of_m_ExecutionContext_13() { return static_cast<int32_t>(offsetof(Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414, ___m_ExecutionContext_13)); }
	inline ExecutionContext_t16AC73BB21FEEEAD34A017877AC18DD8BB836414 * get_m_ExecutionContext_13() const { return ___m_ExecutionContext_13; }
	inline ExecutionContext_t16AC73BB21FEEEAD34A017877AC18DD8BB836414 ** get_address_of_m_ExecutionContext_13() { return &___m_ExecutionContext_13; }
	inline void set_m_ExecutionContext_13(ExecutionContext_t16AC73BB21FEEEAD34A017877AC18DD8BB836414 * value)
	{
		___m_ExecutionContext_13 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_ExecutionContext_13), (void*)value);
	}

	inline static int32_t get_offset_of_m_ExecutionContextBelongsToOuterScope_14() { return static_cast<int32_t>(offsetof(Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414, ___m_ExecutionContextBelongsToOuterScope_14)); }
	inline bool get_m_ExecutionContextBelongsToOuterScope_14() const { return ___m_ExecutionContextBelongsToOuterScope_14; }
	inline bool* get_address_of_m_ExecutionContextBelongsToOuterScope_14() { return &___m_ExecutionContextBelongsToOuterScope_14; }
	inline void set_m_ExecutionContextBelongsToOuterScope_14(bool value)
	{
		___m_ExecutionContextBelongsToOuterScope_14 = value;
	}
};

struct Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414_StaticFields
{
public:
	// System.LocalDataStoreMgr System.Threading.Thread::s_LocalDataStoreMgr
	LocalDataStoreMgr_t6CC44D0584911B6A6C6823115F858FC34AB4A80A * ___s_LocalDataStoreMgr_0;
	// System.Threading.AsyncLocal`1<System.Globalization.CultureInfo> System.Threading.Thread::s_asyncLocalCurrentCulture
	AsyncLocal_1_t480A201BA0D1C62C2C6FA6598EEDF7BB35D85349 * ___s_asyncLocalCurrentCulture_4;
	// System.Threading.AsyncLocal`1<System.Globalization.CultureInfo> System.Threading.Thread::s_asyncLocalCurrentUICulture
	AsyncLocal_1_t480A201BA0D1C62C2C6FA6598EEDF7BB35D85349 * ___s_asyncLocalCurrentUICulture_5;

public:
	inline static int32_t get_offset_of_s_LocalDataStoreMgr_0() { return static_cast<int32_t>(offsetof(Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414_StaticFields, ___s_LocalDataStoreMgr_0)); }
	inline LocalDataStoreMgr_t6CC44D0584911B6A6C6823115F858FC34AB4A80A * get_s_LocalDataStoreMgr_0() const { return ___s_LocalDataStoreMgr_0; }
	inline LocalDataStoreMgr_t6CC44D0584911B6A6C6823115F858FC34AB4A80A ** get_address_of_s_LocalDataStoreMgr_0() { return &___s_LocalDataStoreMgr_0; }
	inline void set_s_LocalDataStoreMgr_0(LocalDataStoreMgr_t6CC44D0584911B6A6C6823115F858FC34AB4A80A * value)
	{
		___s_LocalDataStoreMgr_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_LocalDataStoreMgr_0), (void*)value);
	}

	inline static int32_t get_offset_of_s_asyncLocalCurrentCulture_4() { return static_cast<int32_t>(offsetof(Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414_StaticFields, ___s_asyncLocalCurrentCulture_4)); }
	inline AsyncLocal_1_t480A201BA0D1C62C2C6FA6598EEDF7BB35D85349 * get_s_asyncLocalCurrentCulture_4() const { return ___s_asyncLocalCurrentCulture_4; }
	inline AsyncLocal_1_t480A201BA0D1C62C2C6FA6598EEDF7BB35D85349 ** get_address_of_s_asyncLocalCurrentCulture_4() { return &___s_asyncLocalCurrentCulture_4; }
	inline void set_s_asyncLocalCurrentCulture_4(AsyncLocal_1_t480A201BA0D1C62C2C6FA6598EEDF7BB35D85349 * value)
	{
		___s_asyncLocalCurrentCulture_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_asyncLocalCurrentCulture_4), (void*)value);
	}

	inline static int32_t get_offset_of_s_asyncLocalCurrentUICulture_5() { return static_cast<int32_t>(offsetof(Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414_StaticFields, ___s_asyncLocalCurrentUICulture_5)); }
	inline AsyncLocal_1_t480A201BA0D1C62C2C6FA6598EEDF7BB35D85349 * get_s_asyncLocalCurrentUICulture_5() const { return ___s_asyncLocalCurrentUICulture_5; }
	inline AsyncLocal_1_t480A201BA0D1C62C2C6FA6598EEDF7BB35D85349 ** get_address_of_s_asyncLocalCurrentUICulture_5() { return &___s_asyncLocalCurrentUICulture_5; }
	inline void set_s_asyncLocalCurrentUICulture_5(AsyncLocal_1_t480A201BA0D1C62C2C6FA6598EEDF7BB35D85349 * value)
	{
		___s_asyncLocalCurrentUICulture_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_asyncLocalCurrentUICulture_5), (void*)value);
	}
};

struct Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414_ThreadStaticFields
{
public:
	// System.LocalDataStoreHolder System.Threading.Thread::s_LocalDataStore
	LocalDataStoreHolder_tF51C9DD735A89132114AE47E3EB51C11D0FED146 * ___s_LocalDataStore_1;
	// System.Globalization.CultureInfo System.Threading.Thread::m_CurrentCulture
	CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * ___m_CurrentCulture_2;
	// System.Globalization.CultureInfo System.Threading.Thread::m_CurrentUICulture
	CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * ___m_CurrentUICulture_3;
	// System.Threading.Thread System.Threading.Thread::current_thread
	Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414 * ___current_thread_11;

public:
	inline static int32_t get_offset_of_s_LocalDataStore_1() { return static_cast<int32_t>(offsetof(Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414_ThreadStaticFields, ___s_LocalDataStore_1)); }
	inline LocalDataStoreHolder_tF51C9DD735A89132114AE47E3EB51C11D0FED146 * get_s_LocalDataStore_1() const { return ___s_LocalDataStore_1; }
	inline LocalDataStoreHolder_tF51C9DD735A89132114AE47E3EB51C11D0FED146 ** get_address_of_s_LocalDataStore_1() { return &___s_LocalDataStore_1; }
	inline void set_s_LocalDataStore_1(LocalDataStoreHolder_tF51C9DD735A89132114AE47E3EB51C11D0FED146 * value)
	{
		___s_LocalDataStore_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_LocalDataStore_1), (void*)value);
	}

	inline static int32_t get_offset_of_m_CurrentCulture_2() { return static_cast<int32_t>(offsetof(Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414_ThreadStaticFields, ___m_CurrentCulture_2)); }
	inline CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * get_m_CurrentCulture_2() const { return ___m_CurrentCulture_2; }
	inline CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 ** get_address_of_m_CurrentCulture_2() { return &___m_CurrentCulture_2; }
	inline void set_m_CurrentCulture_2(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * value)
	{
		___m_CurrentCulture_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_CurrentCulture_2), (void*)value);
	}

	inline static int32_t get_offset_of_m_CurrentUICulture_3() { return static_cast<int32_t>(offsetof(Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414_ThreadStaticFields, ___m_CurrentUICulture_3)); }
	inline CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * get_m_CurrentUICulture_3() const { return ___m_CurrentUICulture_3; }
	inline CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 ** get_address_of_m_CurrentUICulture_3() { return &___m_CurrentUICulture_3; }
	inline void set_m_CurrentUICulture_3(CultureInfo_t1B787142231DB79ABDCE0659823F908A040E9A98 * value)
	{
		___m_CurrentUICulture_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_CurrentUICulture_3), (void*)value);
	}

	inline static int32_t get_offset_of_current_thread_11() { return static_cast<int32_t>(offsetof(Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414_ThreadStaticFields, ___current_thread_11)); }
	inline Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414 * get_current_thread_11() const { return ___current_thread_11; }
	inline Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414 ** get_address_of_current_thread_11() { return &___current_thread_11; }
	inline void set_current_thread_11(Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414 * value)
	{
		___current_thread_11 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___current_thread_11), (void*)value);
	}
};


// System.UInt32
struct UInt32_tE60352A06233E4E69DD198BCC67142159F686B15 
{
public:
	// System.UInt32 System.UInt32::m_value
	uint32_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(UInt32_tE60352A06233E4E69DD198BCC67142159F686B15, ___m_value_0)); }
	inline uint32_t get_m_value_0() const { return ___m_value_0; }
	inline uint32_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(uint32_t value)
	{
		___m_value_0 = value;
	}
};


// Bespoke.Common.Net.UdpDataReceivedEventArgs
struct UdpDataReceivedEventArgs_t148E7E67B81BD9271877379526876EBCA1A0B7F0  : public EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA
{
public:
	// System.Net.IPEndPoint Bespoke.Common.Net.UdpDataReceivedEventArgs::mSourceEndPoint
	IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___mSourceEndPoint_1;
	// System.Byte[] Bespoke.Common.Net.UdpDataReceivedEventArgs::mData
	ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___mData_2;

public:
	inline static int32_t get_offset_of_mSourceEndPoint_1() { return static_cast<int32_t>(offsetof(UdpDataReceivedEventArgs_t148E7E67B81BD9271877379526876EBCA1A0B7F0, ___mSourceEndPoint_1)); }
	inline IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * get_mSourceEndPoint_1() const { return ___mSourceEndPoint_1; }
	inline IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E ** get_address_of_mSourceEndPoint_1() { return &___mSourceEndPoint_1; }
	inline void set_mSourceEndPoint_1(IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * value)
	{
		___mSourceEndPoint_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mSourceEndPoint_1), (void*)value);
	}

	inline static int32_t get_offset_of_mData_2() { return static_cast<int32_t>(offsetof(UdpDataReceivedEventArgs_t148E7E67B81BD9271877379526876EBCA1A0B7F0, ___mData_2)); }
	inline ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* get_mData_2() const { return ___mData_2; }
	inline ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726** get_address_of_mData_2() { return &___mData_2; }
	inline void set_mData_2(ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* value)
	{
		___mData_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mData_2), (void*)value);
	}
};


// System.Void
struct Void_t700C6383A2A510C2CF4DD86DABD5CA9FF70ADAC5 
{
public:
	union
	{
		struct
		{
		};
		uint8_t Void_t700C6383A2A510C2CF4DD86DABD5CA9FF70ADAC5__padding[1];
	};

public:
};


// System.Net.Sockets.AddressFamily
struct AddressFamily_tFCF4C888B95C069AB2D4720EC8C2E19453C28B33 
{
public:
	// System.Int32 System.Net.Sockets.AddressFamily::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(AddressFamily_tFCF4C888B95C069AB2D4720EC8C2E19453C28B33, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// System.DateTimeKind
struct DateTimeKind_tA0B5F3F88991AC3B7F24393E15B54062722571D0 
{
public:
	// System.Int32 System.DateTimeKind::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(DateTimeKind_tA0B5F3F88991AC3B7F24393E15B54062722571D0, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// System.Delegate
struct Delegate_t  : public RuntimeObject
{
public:
	// System.IntPtr System.Delegate::method_ptr
	Il2CppMethodPointer ___method_ptr_0;
	// System.IntPtr System.Delegate::invoke_impl
	intptr_t ___invoke_impl_1;
	// System.Object System.Delegate::m_target
	RuntimeObject * ___m_target_2;
	// System.IntPtr System.Delegate::method
	intptr_t ___method_3;
	// System.IntPtr System.Delegate::delegate_trampoline
	intptr_t ___delegate_trampoline_4;
	// System.IntPtr System.Delegate::extra_arg
	intptr_t ___extra_arg_5;
	// System.IntPtr System.Delegate::method_code
	intptr_t ___method_code_6;
	// System.Reflection.MethodInfo System.Delegate::method_info
	MethodInfo_t * ___method_info_7;
	// System.Reflection.MethodInfo System.Delegate::original_method_info
	MethodInfo_t * ___original_method_info_8;
	// System.DelegateData System.Delegate::data
	DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288 * ___data_9;
	// System.Boolean System.Delegate::method_is_virtual
	bool ___method_is_virtual_10;

public:
	inline static int32_t get_offset_of_method_ptr_0() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_ptr_0)); }
	inline Il2CppMethodPointer get_method_ptr_0() const { return ___method_ptr_0; }
	inline Il2CppMethodPointer* get_address_of_method_ptr_0() { return &___method_ptr_0; }
	inline void set_method_ptr_0(Il2CppMethodPointer value)
	{
		___method_ptr_0 = value;
	}

	inline static int32_t get_offset_of_invoke_impl_1() { return static_cast<int32_t>(offsetof(Delegate_t, ___invoke_impl_1)); }
	inline intptr_t get_invoke_impl_1() const { return ___invoke_impl_1; }
	inline intptr_t* get_address_of_invoke_impl_1() { return &___invoke_impl_1; }
	inline void set_invoke_impl_1(intptr_t value)
	{
		___invoke_impl_1 = value;
	}

	inline static int32_t get_offset_of_m_target_2() { return static_cast<int32_t>(offsetof(Delegate_t, ___m_target_2)); }
	inline RuntimeObject * get_m_target_2() const { return ___m_target_2; }
	inline RuntimeObject ** get_address_of_m_target_2() { return &___m_target_2; }
	inline void set_m_target_2(RuntimeObject * value)
	{
		___m_target_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_target_2), (void*)value);
	}

	inline static int32_t get_offset_of_method_3() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_3)); }
	inline intptr_t get_method_3() const { return ___method_3; }
	inline intptr_t* get_address_of_method_3() { return &___method_3; }
	inline void set_method_3(intptr_t value)
	{
		___method_3 = value;
	}

	inline static int32_t get_offset_of_delegate_trampoline_4() { return static_cast<int32_t>(offsetof(Delegate_t, ___delegate_trampoline_4)); }
	inline intptr_t get_delegate_trampoline_4() const { return ___delegate_trampoline_4; }
	inline intptr_t* get_address_of_delegate_trampoline_4() { return &___delegate_trampoline_4; }
	inline void set_delegate_trampoline_4(intptr_t value)
	{
		___delegate_trampoline_4 = value;
	}

	inline static int32_t get_offset_of_extra_arg_5() { return static_cast<int32_t>(offsetof(Delegate_t, ___extra_arg_5)); }
	inline intptr_t get_extra_arg_5() const { return ___extra_arg_5; }
	inline intptr_t* get_address_of_extra_arg_5() { return &___extra_arg_5; }
	inline void set_extra_arg_5(intptr_t value)
	{
		___extra_arg_5 = value;
	}

	inline static int32_t get_offset_of_method_code_6() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_code_6)); }
	inline intptr_t get_method_code_6() const { return ___method_code_6; }
	inline intptr_t* get_address_of_method_code_6() { return &___method_code_6; }
	inline void set_method_code_6(intptr_t value)
	{
		___method_code_6 = value;
	}

	inline static int32_t get_offset_of_method_info_7() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_info_7)); }
	inline MethodInfo_t * get_method_info_7() const { return ___method_info_7; }
	inline MethodInfo_t ** get_address_of_method_info_7() { return &___method_info_7; }
	inline void set_method_info_7(MethodInfo_t * value)
	{
		___method_info_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___method_info_7), (void*)value);
	}

	inline static int32_t get_offset_of_original_method_info_8() { return static_cast<int32_t>(offsetof(Delegate_t, ___original_method_info_8)); }
	inline MethodInfo_t * get_original_method_info_8() const { return ___original_method_info_8; }
	inline MethodInfo_t ** get_address_of_original_method_info_8() { return &___original_method_info_8; }
	inline void set_original_method_info_8(MethodInfo_t * value)
	{
		___original_method_info_8 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___original_method_info_8), (void*)value);
	}

	inline static int32_t get_offset_of_data_9() { return static_cast<int32_t>(offsetof(Delegate_t, ___data_9)); }
	inline DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288 * get_data_9() const { return ___data_9; }
	inline DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288 ** get_address_of_data_9() { return &___data_9; }
	inline void set_data_9(DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288 * value)
	{
		___data_9 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___data_9), (void*)value);
	}

	inline static int32_t get_offset_of_method_is_virtual_10() { return static_cast<int32_t>(offsetof(Delegate_t, ___method_is_virtual_10)); }
	inline bool get_method_is_virtual_10() const { return ___method_is_virtual_10; }
	inline bool* get_address_of_method_is_virtual_10() { return &___method_is_virtual_10; }
	inline void set_method_is_virtual_10(bool value)
	{
		___method_is_virtual_10 = value;
	}
};

// Native definition for P/Invoke marshalling of System.Delegate
struct Delegate_t_marshaled_pinvoke
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	MethodInfo_t * ___method_info_7;
	MethodInfo_t * ___original_method_info_8;
	DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288 * ___data_9;
	int32_t ___method_is_virtual_10;
};
// Native definition for COM marshalling of System.Delegate
struct Delegate_t_marshaled_com
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	MethodInfo_t * ___method_info_7;
	MethodInfo_t * ___original_method_info_8;
	DelegateData_t17DD30660E330C49381DAA99F934BE75CB11F288 * ___data_9;
	int32_t ___method_is_virtual_10;
};

// System.Exception
struct Exception_t  : public RuntimeObject
{
public:
	// System.String System.Exception::_className
	String_t* ____className_1;
	// System.String System.Exception::_message
	String_t* ____message_2;
	// System.Collections.IDictionary System.Exception::_data
	RuntimeObject* ____data_3;
	// System.Exception System.Exception::_innerException
	Exception_t * ____innerException_4;
	// System.String System.Exception::_helpURL
	String_t* ____helpURL_5;
	// System.Object System.Exception::_stackTrace
	RuntimeObject * ____stackTrace_6;
	// System.String System.Exception::_stackTraceString
	String_t* ____stackTraceString_7;
	// System.String System.Exception::_remoteStackTraceString
	String_t* ____remoteStackTraceString_8;
	// System.Int32 System.Exception::_remoteStackIndex
	int32_t ____remoteStackIndex_9;
	// System.Object System.Exception::_dynamicMethods
	RuntimeObject * ____dynamicMethods_10;
	// System.Int32 System.Exception::_HResult
	int32_t ____HResult_11;
	// System.String System.Exception::_source
	String_t* ____source_12;
	// System.Runtime.Serialization.SafeSerializationManager System.Exception::_safeSerializationManager
	SafeSerializationManager_tDE44F029589A028F8A3053C5C06153FAB4AAE29F * ____safeSerializationManager_13;
	// System.Diagnostics.StackTrace[] System.Exception::captured_traces
	StackTraceU5BU5D_t4AD999C288CB6D1F38A299D12B1598D606588971* ___captured_traces_14;
	// System.IntPtr[] System.Exception::native_trace_ips
	IntPtrU5BU5D_t27FC72B0409D75AAF33EC42498E8094E95FEE9A6* ___native_trace_ips_15;

public:
	inline static int32_t get_offset_of__className_1() { return static_cast<int32_t>(offsetof(Exception_t, ____className_1)); }
	inline String_t* get__className_1() const { return ____className_1; }
	inline String_t** get_address_of__className_1() { return &____className_1; }
	inline void set__className_1(String_t* value)
	{
		____className_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____className_1), (void*)value);
	}

	inline static int32_t get_offset_of__message_2() { return static_cast<int32_t>(offsetof(Exception_t, ____message_2)); }
	inline String_t* get__message_2() const { return ____message_2; }
	inline String_t** get_address_of__message_2() { return &____message_2; }
	inline void set__message_2(String_t* value)
	{
		____message_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____message_2), (void*)value);
	}

	inline static int32_t get_offset_of__data_3() { return static_cast<int32_t>(offsetof(Exception_t, ____data_3)); }
	inline RuntimeObject* get__data_3() const { return ____data_3; }
	inline RuntimeObject** get_address_of__data_3() { return &____data_3; }
	inline void set__data_3(RuntimeObject* value)
	{
		____data_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____data_3), (void*)value);
	}

	inline static int32_t get_offset_of__innerException_4() { return static_cast<int32_t>(offsetof(Exception_t, ____innerException_4)); }
	inline Exception_t * get__innerException_4() const { return ____innerException_4; }
	inline Exception_t ** get_address_of__innerException_4() { return &____innerException_4; }
	inline void set__innerException_4(Exception_t * value)
	{
		____innerException_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____innerException_4), (void*)value);
	}

	inline static int32_t get_offset_of__helpURL_5() { return static_cast<int32_t>(offsetof(Exception_t, ____helpURL_5)); }
	inline String_t* get__helpURL_5() const { return ____helpURL_5; }
	inline String_t** get_address_of__helpURL_5() { return &____helpURL_5; }
	inline void set__helpURL_5(String_t* value)
	{
		____helpURL_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____helpURL_5), (void*)value);
	}

	inline static int32_t get_offset_of__stackTrace_6() { return static_cast<int32_t>(offsetof(Exception_t, ____stackTrace_6)); }
	inline RuntimeObject * get__stackTrace_6() const { return ____stackTrace_6; }
	inline RuntimeObject ** get_address_of__stackTrace_6() { return &____stackTrace_6; }
	inline void set__stackTrace_6(RuntimeObject * value)
	{
		____stackTrace_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____stackTrace_6), (void*)value);
	}

	inline static int32_t get_offset_of__stackTraceString_7() { return static_cast<int32_t>(offsetof(Exception_t, ____stackTraceString_7)); }
	inline String_t* get__stackTraceString_7() const { return ____stackTraceString_7; }
	inline String_t** get_address_of__stackTraceString_7() { return &____stackTraceString_7; }
	inline void set__stackTraceString_7(String_t* value)
	{
		____stackTraceString_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____stackTraceString_7), (void*)value);
	}

	inline static int32_t get_offset_of__remoteStackTraceString_8() { return static_cast<int32_t>(offsetof(Exception_t, ____remoteStackTraceString_8)); }
	inline String_t* get__remoteStackTraceString_8() const { return ____remoteStackTraceString_8; }
	inline String_t** get_address_of__remoteStackTraceString_8() { return &____remoteStackTraceString_8; }
	inline void set__remoteStackTraceString_8(String_t* value)
	{
		____remoteStackTraceString_8 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____remoteStackTraceString_8), (void*)value);
	}

	inline static int32_t get_offset_of__remoteStackIndex_9() { return static_cast<int32_t>(offsetof(Exception_t, ____remoteStackIndex_9)); }
	inline int32_t get__remoteStackIndex_9() const { return ____remoteStackIndex_9; }
	inline int32_t* get_address_of__remoteStackIndex_9() { return &____remoteStackIndex_9; }
	inline void set__remoteStackIndex_9(int32_t value)
	{
		____remoteStackIndex_9 = value;
	}

	inline static int32_t get_offset_of__dynamicMethods_10() { return static_cast<int32_t>(offsetof(Exception_t, ____dynamicMethods_10)); }
	inline RuntimeObject * get__dynamicMethods_10() const { return ____dynamicMethods_10; }
	inline RuntimeObject ** get_address_of__dynamicMethods_10() { return &____dynamicMethods_10; }
	inline void set__dynamicMethods_10(RuntimeObject * value)
	{
		____dynamicMethods_10 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____dynamicMethods_10), (void*)value);
	}

	inline static int32_t get_offset_of__HResult_11() { return static_cast<int32_t>(offsetof(Exception_t, ____HResult_11)); }
	inline int32_t get__HResult_11() const { return ____HResult_11; }
	inline int32_t* get_address_of__HResult_11() { return &____HResult_11; }
	inline void set__HResult_11(int32_t value)
	{
		____HResult_11 = value;
	}

	inline static int32_t get_offset_of__source_12() { return static_cast<int32_t>(offsetof(Exception_t, ____source_12)); }
	inline String_t* get__source_12() const { return ____source_12; }
	inline String_t** get_address_of__source_12() { return &____source_12; }
	inline void set__source_12(String_t* value)
	{
		____source_12 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____source_12), (void*)value);
	}

	inline static int32_t get_offset_of__safeSerializationManager_13() { return static_cast<int32_t>(offsetof(Exception_t, ____safeSerializationManager_13)); }
	inline SafeSerializationManager_tDE44F029589A028F8A3053C5C06153FAB4AAE29F * get__safeSerializationManager_13() const { return ____safeSerializationManager_13; }
	inline SafeSerializationManager_tDE44F029589A028F8A3053C5C06153FAB4AAE29F ** get_address_of__safeSerializationManager_13() { return &____safeSerializationManager_13; }
	inline void set__safeSerializationManager_13(SafeSerializationManager_tDE44F029589A028F8A3053C5C06153FAB4AAE29F * value)
	{
		____safeSerializationManager_13 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____safeSerializationManager_13), (void*)value);
	}

	inline static int32_t get_offset_of_captured_traces_14() { return static_cast<int32_t>(offsetof(Exception_t, ___captured_traces_14)); }
	inline StackTraceU5BU5D_t4AD999C288CB6D1F38A299D12B1598D606588971* get_captured_traces_14() const { return ___captured_traces_14; }
	inline StackTraceU5BU5D_t4AD999C288CB6D1F38A299D12B1598D606588971** get_address_of_captured_traces_14() { return &___captured_traces_14; }
	inline void set_captured_traces_14(StackTraceU5BU5D_t4AD999C288CB6D1F38A299D12B1598D606588971* value)
	{
		___captured_traces_14 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___captured_traces_14), (void*)value);
	}

	inline static int32_t get_offset_of_native_trace_ips_15() { return static_cast<int32_t>(offsetof(Exception_t, ___native_trace_ips_15)); }
	inline IntPtrU5BU5D_t27FC72B0409D75AAF33EC42498E8094E95FEE9A6* get_native_trace_ips_15() const { return ___native_trace_ips_15; }
	inline IntPtrU5BU5D_t27FC72B0409D75AAF33EC42498E8094E95FEE9A6** get_address_of_native_trace_ips_15() { return &___native_trace_ips_15; }
	inline void set_native_trace_ips_15(IntPtrU5BU5D_t27FC72B0409D75AAF33EC42498E8094E95FEE9A6* value)
	{
		___native_trace_ips_15 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___native_trace_ips_15), (void*)value);
	}
};

struct Exception_t_StaticFields
{
public:
	// System.Object System.Exception::s_EDILock
	RuntimeObject * ___s_EDILock_0;

public:
	inline static int32_t get_offset_of_s_EDILock_0() { return static_cast<int32_t>(offsetof(Exception_t_StaticFields, ___s_EDILock_0)); }
	inline RuntimeObject * get_s_EDILock_0() const { return ___s_EDILock_0; }
	inline RuntimeObject ** get_address_of_s_EDILock_0() { return &___s_EDILock_0; }
	inline void set_s_EDILock_0(RuntimeObject * value)
	{
		___s_EDILock_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_EDILock_0), (void*)value);
	}
};

// Native definition for P/Invoke marshalling of System.Exception
struct Exception_t_marshaled_pinvoke
{
	char* ____className_1;
	char* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_pinvoke* ____innerException_4;
	char* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	char* ____stackTraceString_7;
	char* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	char* ____source_12;
	SafeSerializationManager_tDE44F029589A028F8A3053C5C06153FAB4AAE29F * ____safeSerializationManager_13;
	StackTraceU5BU5D_t4AD999C288CB6D1F38A299D12B1598D606588971* ___captured_traces_14;
	Il2CppSafeArray/*NONE*/* ___native_trace_ips_15;
};
// Native definition for COM marshalling of System.Exception
struct Exception_t_marshaled_com
{
	Il2CppChar* ____className_1;
	Il2CppChar* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_com* ____innerException_4;
	Il2CppChar* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	Il2CppChar* ____stackTraceString_7;
	Il2CppChar* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	Il2CppChar* ____source_12;
	SafeSerializationManager_tDE44F029589A028F8A3053C5C06153FAB4AAE29F * ____safeSerializationManager_13;
	StackTraceU5BU5D_t4AD999C288CB6D1F38A299D12B1598D606588971* ___captured_traces_14;
	Il2CppSafeArray/*NONE*/* ___native_trace_ips_15;
};

// Bespoke.Common.Osc.OscTimeTag
struct OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB  : public RuntimeObject
{
public:
	// System.DateTime Bespoke.Common.Osc.OscTimeTag::mTimeStamp
	DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  ___mTimeStamp_2;

public:
	inline static int32_t get_offset_of_mTimeStamp_2() { return static_cast<int32_t>(offsetof(OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB, ___mTimeStamp_2)); }
	inline DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  get_mTimeStamp_2() const { return ___mTimeStamp_2; }
	inline DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 * get_address_of_mTimeStamp_2() { return &___mTimeStamp_2; }
	inline void set_mTimeStamp_2(DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  value)
	{
		___mTimeStamp_2 = value;
	}
};

struct OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_StaticFields
{
public:
	// System.DateTime Bespoke.Common.Osc.OscTimeTag::Epoch
	DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  ___Epoch_0;
	// Bespoke.Common.Osc.OscTimeTag Bespoke.Common.Osc.OscTimeTag::MinValue
	OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * ___MinValue_1;

public:
	inline static int32_t get_offset_of_Epoch_0() { return static_cast<int32_t>(offsetof(OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_StaticFields, ___Epoch_0)); }
	inline DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  get_Epoch_0() const { return ___Epoch_0; }
	inline DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 * get_address_of_Epoch_0() { return &___Epoch_0; }
	inline void set_Epoch_0(DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  value)
	{
		___Epoch_0 = value;
	}

	inline static int32_t get_offset_of_MinValue_1() { return static_cast<int32_t>(offsetof(OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_StaticFields, ___MinValue_1)); }
	inline OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * get_MinValue_1() const { return ___MinValue_1; }
	inline OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB ** get_address_of_MinValue_1() { return &___MinValue_1; }
	inline void set_MinValue_1(OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * value)
	{
		___MinValue_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___MinValue_1), (void*)value);
	}
};


// System.Net.Sockets.ProtocolType
struct ProtocolType_t07C7AB65B583B132A2D99BC06BB2A909BDDCE156 
{
public:
	// System.Int32 System.Net.Sockets.ProtocolType::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(ProtocolType_t07C7AB65B583B132A2D99BC06BB2A909BDDCE156, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// System.Net.Sockets.SocketType
struct SocketType_t234FBD298C115F92305ABC40D2E592FC535DFF94 
{
public:
	// System.Int32 System.Net.Sockets.SocketType::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(SocketType_t234FBD298C115F92305ABC40D2E592FC535DFF94, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// Bespoke.Common.Net.TcpServer
struct TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17  : public IPServer_tBEF36D7D3CD1DEBACE97ACE01D198E4EA25D3C06
{
public:
	// System.EventHandler`1<Bespoke.Common.Net.TcpConnectionEventArgs> Bespoke.Common.Net.TcpServer::Connected
	EventHandler_1_t3782CAFC23B84FE2565AA899369F210C80E75ECF * ___Connected_1;
	// System.EventHandler`1<Bespoke.Common.Net.TcpConnectionEventArgs> Bespoke.Common.Net.TcpServer::Disconnected
	EventHandler_1_t3782CAFC23B84FE2565AA899369F210C80E75ECF * ___Disconnected_2;
	// System.EventHandler`1<Bespoke.Common.Net.TcpDataReceivedEventArgs> Bespoke.Common.Net.TcpServer::DataReceived
	EventHandler_1_tEFAA9D3F682231A3C61310E1CE32DB931BBBAE43 * ___DataReceived_3;
	// System.Net.IPAddress Bespoke.Common.Net.TcpServer::mIPAddress
	IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___mIPAddress_4;
	// System.Int32 Bespoke.Common.Net.TcpServer::mPort
	int32_t ___mPort_5;
	// System.Collections.Generic.List`1<Bespoke.Common.Net.TcpConnection> Bespoke.Common.Net.TcpServer::mClientConnections
	List_1_t8437E2CEB9C2C34412935AD0B393192619E1C7C8 * ___mClientConnections_6;
	// System.Collections.Generic.List`1<Bespoke.Common.Net.TcpConnection> Bespoke.Common.Net.TcpServer::mConnectionsToClose
	List_1_t8437E2CEB9C2C34412935AD0B393192619E1C7C8 * ___mConnectionsToClose_7;
	// System.Boolean Bespoke.Common.Net.TcpServer::mReceiveDataInline
	bool ___mReceiveDataInline_8;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) Bespoke.Common.Net.TcpServer::mIsShuttingDown
	bool ___mIsShuttingDown_9;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) Bespoke.Common.Net.TcpServer::mAcceptingConnections
	bool ___mAcceptingConnections_10;
	// System.Threading.ManualResetEvent Bespoke.Common.Net.TcpServer::mListenerReady
	ManualResetEvent_t9E2ED486907E3A16122ED4E946534E4DD6B5A7BA * ___mListenerReady_11;
	// System.Boolean Bespoke.Common.Net.TcpServer::mLittleEndianByteOrder
	bool ___mLittleEndianByteOrder_12;

public:
	inline static int32_t get_offset_of_Connected_1() { return static_cast<int32_t>(offsetof(TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17, ___Connected_1)); }
	inline EventHandler_1_t3782CAFC23B84FE2565AA899369F210C80E75ECF * get_Connected_1() const { return ___Connected_1; }
	inline EventHandler_1_t3782CAFC23B84FE2565AA899369F210C80E75ECF ** get_address_of_Connected_1() { return &___Connected_1; }
	inline void set_Connected_1(EventHandler_1_t3782CAFC23B84FE2565AA899369F210C80E75ECF * value)
	{
		___Connected_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Connected_1), (void*)value);
	}

	inline static int32_t get_offset_of_Disconnected_2() { return static_cast<int32_t>(offsetof(TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17, ___Disconnected_2)); }
	inline EventHandler_1_t3782CAFC23B84FE2565AA899369F210C80E75ECF * get_Disconnected_2() const { return ___Disconnected_2; }
	inline EventHandler_1_t3782CAFC23B84FE2565AA899369F210C80E75ECF ** get_address_of_Disconnected_2() { return &___Disconnected_2; }
	inline void set_Disconnected_2(EventHandler_1_t3782CAFC23B84FE2565AA899369F210C80E75ECF * value)
	{
		___Disconnected_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Disconnected_2), (void*)value);
	}

	inline static int32_t get_offset_of_DataReceived_3() { return static_cast<int32_t>(offsetof(TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17, ___DataReceived_3)); }
	inline EventHandler_1_tEFAA9D3F682231A3C61310E1CE32DB931BBBAE43 * get_DataReceived_3() const { return ___DataReceived_3; }
	inline EventHandler_1_tEFAA9D3F682231A3C61310E1CE32DB931BBBAE43 ** get_address_of_DataReceived_3() { return &___DataReceived_3; }
	inline void set_DataReceived_3(EventHandler_1_tEFAA9D3F682231A3C61310E1CE32DB931BBBAE43 * value)
	{
		___DataReceived_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___DataReceived_3), (void*)value);
	}

	inline static int32_t get_offset_of_mIPAddress_4() { return static_cast<int32_t>(offsetof(TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17, ___mIPAddress_4)); }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * get_mIPAddress_4() const { return ___mIPAddress_4; }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE ** get_address_of_mIPAddress_4() { return &___mIPAddress_4; }
	inline void set_mIPAddress_4(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * value)
	{
		___mIPAddress_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mIPAddress_4), (void*)value);
	}

	inline static int32_t get_offset_of_mPort_5() { return static_cast<int32_t>(offsetof(TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17, ___mPort_5)); }
	inline int32_t get_mPort_5() const { return ___mPort_5; }
	inline int32_t* get_address_of_mPort_5() { return &___mPort_5; }
	inline void set_mPort_5(int32_t value)
	{
		___mPort_5 = value;
	}

	inline static int32_t get_offset_of_mClientConnections_6() { return static_cast<int32_t>(offsetof(TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17, ___mClientConnections_6)); }
	inline List_1_t8437E2CEB9C2C34412935AD0B393192619E1C7C8 * get_mClientConnections_6() const { return ___mClientConnections_6; }
	inline List_1_t8437E2CEB9C2C34412935AD0B393192619E1C7C8 ** get_address_of_mClientConnections_6() { return &___mClientConnections_6; }
	inline void set_mClientConnections_6(List_1_t8437E2CEB9C2C34412935AD0B393192619E1C7C8 * value)
	{
		___mClientConnections_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mClientConnections_6), (void*)value);
	}

	inline static int32_t get_offset_of_mConnectionsToClose_7() { return static_cast<int32_t>(offsetof(TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17, ___mConnectionsToClose_7)); }
	inline List_1_t8437E2CEB9C2C34412935AD0B393192619E1C7C8 * get_mConnectionsToClose_7() const { return ___mConnectionsToClose_7; }
	inline List_1_t8437E2CEB9C2C34412935AD0B393192619E1C7C8 ** get_address_of_mConnectionsToClose_7() { return &___mConnectionsToClose_7; }
	inline void set_mConnectionsToClose_7(List_1_t8437E2CEB9C2C34412935AD0B393192619E1C7C8 * value)
	{
		___mConnectionsToClose_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mConnectionsToClose_7), (void*)value);
	}

	inline static int32_t get_offset_of_mReceiveDataInline_8() { return static_cast<int32_t>(offsetof(TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17, ___mReceiveDataInline_8)); }
	inline bool get_mReceiveDataInline_8() const { return ___mReceiveDataInline_8; }
	inline bool* get_address_of_mReceiveDataInline_8() { return &___mReceiveDataInline_8; }
	inline void set_mReceiveDataInline_8(bool value)
	{
		___mReceiveDataInline_8 = value;
	}

	inline static int32_t get_offset_of_mIsShuttingDown_9() { return static_cast<int32_t>(offsetof(TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17, ___mIsShuttingDown_9)); }
	inline bool get_mIsShuttingDown_9() const { return ___mIsShuttingDown_9; }
	inline bool* get_address_of_mIsShuttingDown_9() { return &___mIsShuttingDown_9; }
	inline void set_mIsShuttingDown_9(bool value)
	{
		___mIsShuttingDown_9 = value;
	}

	inline static int32_t get_offset_of_mAcceptingConnections_10() { return static_cast<int32_t>(offsetof(TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17, ___mAcceptingConnections_10)); }
	inline bool get_mAcceptingConnections_10() const { return ___mAcceptingConnections_10; }
	inline bool* get_address_of_mAcceptingConnections_10() { return &___mAcceptingConnections_10; }
	inline void set_mAcceptingConnections_10(bool value)
	{
		___mAcceptingConnections_10 = value;
	}

	inline static int32_t get_offset_of_mListenerReady_11() { return static_cast<int32_t>(offsetof(TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17, ___mListenerReady_11)); }
	inline ManualResetEvent_t9E2ED486907E3A16122ED4E946534E4DD6B5A7BA * get_mListenerReady_11() const { return ___mListenerReady_11; }
	inline ManualResetEvent_t9E2ED486907E3A16122ED4E946534E4DD6B5A7BA ** get_address_of_mListenerReady_11() { return &___mListenerReady_11; }
	inline void set_mListenerReady_11(ManualResetEvent_t9E2ED486907E3A16122ED4E946534E4DD6B5A7BA * value)
	{
		___mListenerReady_11 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mListenerReady_11), (void*)value);
	}

	inline static int32_t get_offset_of_mLittleEndianByteOrder_12() { return static_cast<int32_t>(offsetof(TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17, ___mLittleEndianByteOrder_12)); }
	inline bool get_mLittleEndianByteOrder_12() const { return ___mLittleEndianByteOrder_12; }
	inline bool* get_address_of_mLittleEndianByteOrder_12() { return &___mLittleEndianByteOrder_12; }
	inline void set_mLittleEndianByteOrder_12(bool value)
	{
		___mLittleEndianByteOrder_12 = value;
	}
};

struct TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17_StaticFields
{
public:
	// System.Int32 Bespoke.Common.Net.TcpServer::MaxPendingConnections
	int32_t ___MaxPendingConnections_0;

public:
	inline static int32_t get_offset_of_MaxPendingConnections_0() { return static_cast<int32_t>(offsetof(TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17_StaticFields, ___MaxPendingConnections_0)); }
	inline int32_t get_MaxPendingConnections_0() const { return ___MaxPendingConnections_0; }
	inline int32_t* get_address_of_MaxPendingConnections_0() { return &___MaxPendingConnections_0; }
	inline void set_MaxPendingConnections_0(int32_t value)
	{
		___MaxPendingConnections_0 = value;
	}
};


// System.TimeSpan
struct TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203 
{
public:
	// System.Int64 System.TimeSpan::_ticks
	int64_t ____ticks_22;

public:
	inline static int32_t get_offset_of__ticks_22() { return static_cast<int32_t>(offsetof(TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203, ____ticks_22)); }
	inline int64_t get__ticks_22() const { return ____ticks_22; }
	inline int64_t* get_address_of__ticks_22() { return &____ticks_22; }
	inline void set__ticks_22(int64_t value)
	{
		____ticks_22 = value;
	}
};

struct TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203_StaticFields
{
public:
	// System.TimeSpan System.TimeSpan::Zero
	TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203  ___Zero_19;
	// System.TimeSpan System.TimeSpan::MaxValue
	TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203  ___MaxValue_20;
	// System.TimeSpan System.TimeSpan::MinValue
	TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203  ___MinValue_21;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) System.TimeSpan::_legacyConfigChecked
	bool ____legacyConfigChecked_23;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) System.TimeSpan::_legacyMode
	bool ____legacyMode_24;

public:
	inline static int32_t get_offset_of_Zero_19() { return static_cast<int32_t>(offsetof(TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203_StaticFields, ___Zero_19)); }
	inline TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203  get_Zero_19() const { return ___Zero_19; }
	inline TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203 * get_address_of_Zero_19() { return &___Zero_19; }
	inline void set_Zero_19(TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203  value)
	{
		___Zero_19 = value;
	}

	inline static int32_t get_offset_of_MaxValue_20() { return static_cast<int32_t>(offsetof(TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203_StaticFields, ___MaxValue_20)); }
	inline TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203  get_MaxValue_20() const { return ___MaxValue_20; }
	inline TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203 * get_address_of_MaxValue_20() { return &___MaxValue_20; }
	inline void set_MaxValue_20(TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203  value)
	{
		___MaxValue_20 = value;
	}

	inline static int32_t get_offset_of_MinValue_21() { return static_cast<int32_t>(offsetof(TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203_StaticFields, ___MinValue_21)); }
	inline TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203  get_MinValue_21() const { return ___MinValue_21; }
	inline TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203 * get_address_of_MinValue_21() { return &___MinValue_21; }
	inline void set_MinValue_21(TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203  value)
	{
		___MinValue_21 = value;
	}

	inline static int32_t get_offset_of__legacyConfigChecked_23() { return static_cast<int32_t>(offsetof(TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203_StaticFields, ____legacyConfigChecked_23)); }
	inline bool get__legacyConfigChecked_23() const { return ____legacyConfigChecked_23; }
	inline bool* get_address_of__legacyConfigChecked_23() { return &____legacyConfigChecked_23; }
	inline void set__legacyConfigChecked_23(bool value)
	{
		____legacyConfigChecked_23 = value;
	}

	inline static int32_t get_offset_of__legacyMode_24() { return static_cast<int32_t>(offsetof(TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203_StaticFields, ____legacyMode_24)); }
	inline bool get__legacyMode_24() const { return ____legacyMode_24; }
	inline bool* get_address_of__legacyMode_24() { return &____legacyMode_24; }
	inline void set__legacyMode_24(bool value)
	{
		____legacyMode_24 = value;
	}
};


// Bespoke.Common.Net.TransmissionType
struct TransmissionType_tBB22CDC6D994C2D236AC43981C4C8EDB533E194B 
{
public:
	// System.Int32 Bespoke.Common.Net.TransmissionType::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(TransmissionType_tBB22CDC6D994C2D236AC43981C4C8EDB533E194B, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// System.Net.TransportType
struct TransportType_t19FD2303B5B680C76D1B24D778D0959E9AE8198C 
{
public:
	// System.Int32 System.Net.TransportType::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(TransportType_t19FD2303B5B680C76D1B24D778D0959E9AE8198C, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// Bespoke.Common.Net.TcpConnection/DataReceiveState
struct DataReceiveState_tF98FF984D581A77231B80E7F424265627C1CCE67 
{
public:
	// System.Int32 Bespoke.Common.Net.TcpConnection/DataReceiveState::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(DataReceiveState_tF98FF984D581A77231B80E7F424265627C1CCE67, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// System.Net.IPAddress
struct IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE  : public RuntimeObject
{
public:
	// System.Int64 System.Net.IPAddress::m_Address
	int64_t ___m_Address_5;
	// System.String System.Net.IPAddress::m_ToString
	String_t* ___m_ToString_6;
	// System.Net.Sockets.AddressFamily System.Net.IPAddress::m_Family
	int32_t ___m_Family_10;
	// System.UInt16[] System.Net.IPAddress::m_Numbers
	UInt16U5BU5D_t42D35C587B07DCDBCFDADF572C6D733AE85B2A67* ___m_Numbers_11;
	// System.Int64 System.Net.IPAddress::m_ScopeId
	int64_t ___m_ScopeId_12;
	// System.Int32 System.Net.IPAddress::m_HashCode
	int32_t ___m_HashCode_13;

public:
	inline static int32_t get_offset_of_m_Address_5() { return static_cast<int32_t>(offsetof(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE, ___m_Address_5)); }
	inline int64_t get_m_Address_5() const { return ___m_Address_5; }
	inline int64_t* get_address_of_m_Address_5() { return &___m_Address_5; }
	inline void set_m_Address_5(int64_t value)
	{
		___m_Address_5 = value;
	}

	inline static int32_t get_offset_of_m_ToString_6() { return static_cast<int32_t>(offsetof(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE, ___m_ToString_6)); }
	inline String_t* get_m_ToString_6() const { return ___m_ToString_6; }
	inline String_t** get_address_of_m_ToString_6() { return &___m_ToString_6; }
	inline void set_m_ToString_6(String_t* value)
	{
		___m_ToString_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_ToString_6), (void*)value);
	}

	inline static int32_t get_offset_of_m_Family_10() { return static_cast<int32_t>(offsetof(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE, ___m_Family_10)); }
	inline int32_t get_m_Family_10() const { return ___m_Family_10; }
	inline int32_t* get_address_of_m_Family_10() { return &___m_Family_10; }
	inline void set_m_Family_10(int32_t value)
	{
		___m_Family_10 = value;
	}

	inline static int32_t get_offset_of_m_Numbers_11() { return static_cast<int32_t>(offsetof(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE, ___m_Numbers_11)); }
	inline UInt16U5BU5D_t42D35C587B07DCDBCFDADF572C6D733AE85B2A67* get_m_Numbers_11() const { return ___m_Numbers_11; }
	inline UInt16U5BU5D_t42D35C587B07DCDBCFDADF572C6D733AE85B2A67** get_address_of_m_Numbers_11() { return &___m_Numbers_11; }
	inline void set_m_Numbers_11(UInt16U5BU5D_t42D35C587B07DCDBCFDADF572C6D733AE85B2A67* value)
	{
		___m_Numbers_11 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Numbers_11), (void*)value);
	}

	inline static int32_t get_offset_of_m_ScopeId_12() { return static_cast<int32_t>(offsetof(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE, ___m_ScopeId_12)); }
	inline int64_t get_m_ScopeId_12() const { return ___m_ScopeId_12; }
	inline int64_t* get_address_of_m_ScopeId_12() { return &___m_ScopeId_12; }
	inline void set_m_ScopeId_12(int64_t value)
	{
		___m_ScopeId_12 = value;
	}

	inline static int32_t get_offset_of_m_HashCode_13() { return static_cast<int32_t>(offsetof(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE, ___m_HashCode_13)); }
	inline int32_t get_m_HashCode_13() const { return ___m_HashCode_13; }
	inline int32_t* get_address_of_m_HashCode_13() { return &___m_HashCode_13; }
	inline void set_m_HashCode_13(int32_t value)
	{
		___m_HashCode_13 = value;
	}
};

struct IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE_StaticFields
{
public:
	// System.Net.IPAddress System.Net.IPAddress::Any
	IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___Any_0;
	// System.Net.IPAddress System.Net.IPAddress::Loopback
	IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___Loopback_1;
	// System.Net.IPAddress System.Net.IPAddress::Broadcast
	IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___Broadcast_2;
	// System.Net.IPAddress System.Net.IPAddress::None
	IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___None_3;
	// System.Net.IPAddress System.Net.IPAddress::IPv6Any
	IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___IPv6Any_7;
	// System.Net.IPAddress System.Net.IPAddress::IPv6Loopback
	IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___IPv6Loopback_8;
	// System.Net.IPAddress System.Net.IPAddress::IPv6None
	IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___IPv6None_9;

public:
	inline static int32_t get_offset_of_Any_0() { return static_cast<int32_t>(offsetof(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE_StaticFields, ___Any_0)); }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * get_Any_0() const { return ___Any_0; }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE ** get_address_of_Any_0() { return &___Any_0; }
	inline void set_Any_0(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * value)
	{
		___Any_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Any_0), (void*)value);
	}

	inline static int32_t get_offset_of_Loopback_1() { return static_cast<int32_t>(offsetof(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE_StaticFields, ___Loopback_1)); }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * get_Loopback_1() const { return ___Loopback_1; }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE ** get_address_of_Loopback_1() { return &___Loopback_1; }
	inline void set_Loopback_1(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * value)
	{
		___Loopback_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Loopback_1), (void*)value);
	}

	inline static int32_t get_offset_of_Broadcast_2() { return static_cast<int32_t>(offsetof(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE_StaticFields, ___Broadcast_2)); }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * get_Broadcast_2() const { return ___Broadcast_2; }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE ** get_address_of_Broadcast_2() { return &___Broadcast_2; }
	inline void set_Broadcast_2(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * value)
	{
		___Broadcast_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Broadcast_2), (void*)value);
	}

	inline static int32_t get_offset_of_None_3() { return static_cast<int32_t>(offsetof(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE_StaticFields, ___None_3)); }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * get_None_3() const { return ___None_3; }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE ** get_address_of_None_3() { return &___None_3; }
	inline void set_None_3(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * value)
	{
		___None_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___None_3), (void*)value);
	}

	inline static int32_t get_offset_of_IPv6Any_7() { return static_cast<int32_t>(offsetof(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE_StaticFields, ___IPv6Any_7)); }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * get_IPv6Any_7() const { return ___IPv6Any_7; }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE ** get_address_of_IPv6Any_7() { return &___IPv6Any_7; }
	inline void set_IPv6Any_7(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * value)
	{
		___IPv6Any_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___IPv6Any_7), (void*)value);
	}

	inline static int32_t get_offset_of_IPv6Loopback_8() { return static_cast<int32_t>(offsetof(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE_StaticFields, ___IPv6Loopback_8)); }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * get_IPv6Loopback_8() const { return ___IPv6Loopback_8; }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE ** get_address_of_IPv6Loopback_8() { return &___IPv6Loopback_8; }
	inline void set_IPv6Loopback_8(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * value)
	{
		___IPv6Loopback_8 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___IPv6Loopback_8), (void*)value);
	}

	inline static int32_t get_offset_of_IPv6None_9() { return static_cast<int32_t>(offsetof(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE_StaticFields, ___IPv6None_9)); }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * get_IPv6None_9() const { return ___IPv6None_9; }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE ** get_address_of_IPv6None_9() { return &___IPv6None_9; }
	inline void set_IPv6None_9(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * value)
	{
		___IPv6None_9 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___IPv6None_9), (void*)value);
	}
};


// System.MulticastDelegate
struct MulticastDelegate_t  : public Delegate_t
{
public:
	// System.Delegate[] System.MulticastDelegate::delegates
	DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8* ___delegates_11;

public:
	inline static int32_t get_offset_of_delegates_11() { return static_cast<int32_t>(offsetof(MulticastDelegate_t, ___delegates_11)); }
	inline DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8* get_delegates_11() const { return ___delegates_11; }
	inline DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8** get_address_of_delegates_11() { return &___delegates_11; }
	inline void set_delegates_11(DelegateU5BU5D_t677D8FE08A5F99E8EE49150B73966CD6E9BF7DB8* value)
	{
		___delegates_11 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___delegates_11), (void*)value);
	}
};

// Native definition for P/Invoke marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_pinvoke : public Delegate_t_marshaled_pinvoke
{
	Delegate_t_marshaled_pinvoke** ___delegates_11;
};
// Native definition for COM marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_com : public Delegate_t_marshaled_com
{
	Delegate_t_marshaled_com** ___delegates_11;
};

// Bespoke.Common.Osc.OscServer
struct OscServer_tEC9090B8C05007FBB204BE388A8707862015E025  : public IPServer_tBEF36D7D3CD1DEBACE97ACE01D198E4EA25D3C06
{
public:
	// System.EventHandler`1<Bespoke.Common.Osc.OscPacketReceivedEventArgs> Bespoke.Common.Osc.OscServer::PacketReceived
	EventHandler_1_t0AFB60D05E9FCFB34BD7F25226CC0CEE2E7271E4 * ___PacketReceived_0;
	// System.EventHandler`1<Bespoke.Common.Osc.OscBundleReceivedEventArgs> Bespoke.Common.Osc.OscServer::BundleReceived
	EventHandler_1_t129E585D9AA40035BC8D64CA9AE2FB4166FD9AC4 * ___BundleReceived_1;
	// System.EventHandler`1<Bespoke.Common.Osc.OscMessageReceivedEventArgs> Bespoke.Common.Osc.OscServer::MessageReceived
	EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * ___MessageReceived_2;
	// System.EventHandler`1<Bespoke.Common.ExceptionEventArgs> Bespoke.Common.Osc.OscServer::ReceiveErrored
	EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * ___ReceiveErrored_3;
	// System.Net.TransportType Bespoke.Common.Osc.OscServer::mTransportType
	int32_t ___mTransportType_4;
	// System.Net.IPAddress Bespoke.Common.Osc.OscServer::mIPAddress
	IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___mIPAddress_5;
	// System.Int32 Bespoke.Common.Osc.OscServer::mPort
	int32_t ___mPort_6;
	// System.Net.IPEndPoint Bespoke.Common.Osc.OscServer::mIPEndPoint
	IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___mIPEndPoint_7;
	// System.Net.IPAddress Bespoke.Common.Osc.OscServer::mMulticastAddress
	IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___mMulticastAddress_8;
	// Bespoke.Common.Net.UdpServer Bespoke.Common.Osc.OscServer::mUdpServer
	UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2 * ___mUdpServer_9;
	// Bespoke.Common.Net.TcpServer Bespoke.Common.Osc.OscServer::mTcpServer
	TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17 * ___mTcpServer_10;
	// System.Threading.Thread Bespoke.Common.Osc.OscServer::mTcpServerThread
	Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414 * ___mTcpServerThread_11;
	// System.Collections.Generic.List`1<System.String> Bespoke.Common.Osc.OscServer::mRegisteredMethods
	List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 * ___mRegisteredMethods_12;
	// System.Boolean Bespoke.Common.Osc.OscServer::mFilterRegisteredMethods
	bool ___mFilterRegisteredMethods_13;
	// Bespoke.Common.Net.TransmissionType Bespoke.Common.Osc.OscServer::mTransmissionType
	int32_t ___mTransmissionType_14;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) Bespoke.Common.Osc.OscServer::mHandleMessages
	bool ___mHandleMessages_15;
	// System.Boolean Bespoke.Common.Osc.OscServer::mConsumeParsingExceptions
	bool ___mConsumeParsingExceptions_16;

public:
	inline static int32_t get_offset_of_PacketReceived_0() { return static_cast<int32_t>(offsetof(OscServer_tEC9090B8C05007FBB204BE388A8707862015E025, ___PacketReceived_0)); }
	inline EventHandler_1_t0AFB60D05E9FCFB34BD7F25226CC0CEE2E7271E4 * get_PacketReceived_0() const { return ___PacketReceived_0; }
	inline EventHandler_1_t0AFB60D05E9FCFB34BD7F25226CC0CEE2E7271E4 ** get_address_of_PacketReceived_0() { return &___PacketReceived_0; }
	inline void set_PacketReceived_0(EventHandler_1_t0AFB60D05E9FCFB34BD7F25226CC0CEE2E7271E4 * value)
	{
		___PacketReceived_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___PacketReceived_0), (void*)value);
	}

	inline static int32_t get_offset_of_BundleReceived_1() { return static_cast<int32_t>(offsetof(OscServer_tEC9090B8C05007FBB204BE388A8707862015E025, ___BundleReceived_1)); }
	inline EventHandler_1_t129E585D9AA40035BC8D64CA9AE2FB4166FD9AC4 * get_BundleReceived_1() const { return ___BundleReceived_1; }
	inline EventHandler_1_t129E585D9AA40035BC8D64CA9AE2FB4166FD9AC4 ** get_address_of_BundleReceived_1() { return &___BundleReceived_1; }
	inline void set_BundleReceived_1(EventHandler_1_t129E585D9AA40035BC8D64CA9AE2FB4166FD9AC4 * value)
	{
		___BundleReceived_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___BundleReceived_1), (void*)value);
	}

	inline static int32_t get_offset_of_MessageReceived_2() { return static_cast<int32_t>(offsetof(OscServer_tEC9090B8C05007FBB204BE388A8707862015E025, ___MessageReceived_2)); }
	inline EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * get_MessageReceived_2() const { return ___MessageReceived_2; }
	inline EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 ** get_address_of_MessageReceived_2() { return &___MessageReceived_2; }
	inline void set_MessageReceived_2(EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * value)
	{
		___MessageReceived_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___MessageReceived_2), (void*)value);
	}

	inline static int32_t get_offset_of_ReceiveErrored_3() { return static_cast<int32_t>(offsetof(OscServer_tEC9090B8C05007FBB204BE388A8707862015E025, ___ReceiveErrored_3)); }
	inline EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * get_ReceiveErrored_3() const { return ___ReceiveErrored_3; }
	inline EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F ** get_address_of_ReceiveErrored_3() { return &___ReceiveErrored_3; }
	inline void set_ReceiveErrored_3(EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * value)
	{
		___ReceiveErrored_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___ReceiveErrored_3), (void*)value);
	}

	inline static int32_t get_offset_of_mTransportType_4() { return static_cast<int32_t>(offsetof(OscServer_tEC9090B8C05007FBB204BE388A8707862015E025, ___mTransportType_4)); }
	inline int32_t get_mTransportType_4() const { return ___mTransportType_4; }
	inline int32_t* get_address_of_mTransportType_4() { return &___mTransportType_4; }
	inline void set_mTransportType_4(int32_t value)
	{
		___mTransportType_4 = value;
	}

	inline static int32_t get_offset_of_mIPAddress_5() { return static_cast<int32_t>(offsetof(OscServer_tEC9090B8C05007FBB204BE388A8707862015E025, ___mIPAddress_5)); }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * get_mIPAddress_5() const { return ___mIPAddress_5; }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE ** get_address_of_mIPAddress_5() { return &___mIPAddress_5; }
	inline void set_mIPAddress_5(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * value)
	{
		___mIPAddress_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mIPAddress_5), (void*)value);
	}

	inline static int32_t get_offset_of_mPort_6() { return static_cast<int32_t>(offsetof(OscServer_tEC9090B8C05007FBB204BE388A8707862015E025, ___mPort_6)); }
	inline int32_t get_mPort_6() const { return ___mPort_6; }
	inline int32_t* get_address_of_mPort_6() { return &___mPort_6; }
	inline void set_mPort_6(int32_t value)
	{
		___mPort_6 = value;
	}

	inline static int32_t get_offset_of_mIPEndPoint_7() { return static_cast<int32_t>(offsetof(OscServer_tEC9090B8C05007FBB204BE388A8707862015E025, ___mIPEndPoint_7)); }
	inline IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * get_mIPEndPoint_7() const { return ___mIPEndPoint_7; }
	inline IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E ** get_address_of_mIPEndPoint_7() { return &___mIPEndPoint_7; }
	inline void set_mIPEndPoint_7(IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * value)
	{
		___mIPEndPoint_7 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mIPEndPoint_7), (void*)value);
	}

	inline static int32_t get_offset_of_mMulticastAddress_8() { return static_cast<int32_t>(offsetof(OscServer_tEC9090B8C05007FBB204BE388A8707862015E025, ___mMulticastAddress_8)); }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * get_mMulticastAddress_8() const { return ___mMulticastAddress_8; }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE ** get_address_of_mMulticastAddress_8() { return &___mMulticastAddress_8; }
	inline void set_mMulticastAddress_8(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * value)
	{
		___mMulticastAddress_8 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mMulticastAddress_8), (void*)value);
	}

	inline static int32_t get_offset_of_mUdpServer_9() { return static_cast<int32_t>(offsetof(OscServer_tEC9090B8C05007FBB204BE388A8707862015E025, ___mUdpServer_9)); }
	inline UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2 * get_mUdpServer_9() const { return ___mUdpServer_9; }
	inline UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2 ** get_address_of_mUdpServer_9() { return &___mUdpServer_9; }
	inline void set_mUdpServer_9(UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2 * value)
	{
		___mUdpServer_9 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mUdpServer_9), (void*)value);
	}

	inline static int32_t get_offset_of_mTcpServer_10() { return static_cast<int32_t>(offsetof(OscServer_tEC9090B8C05007FBB204BE388A8707862015E025, ___mTcpServer_10)); }
	inline TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17 * get_mTcpServer_10() const { return ___mTcpServer_10; }
	inline TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17 ** get_address_of_mTcpServer_10() { return &___mTcpServer_10; }
	inline void set_mTcpServer_10(TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17 * value)
	{
		___mTcpServer_10 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mTcpServer_10), (void*)value);
	}

	inline static int32_t get_offset_of_mTcpServerThread_11() { return static_cast<int32_t>(offsetof(OscServer_tEC9090B8C05007FBB204BE388A8707862015E025, ___mTcpServerThread_11)); }
	inline Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414 * get_mTcpServerThread_11() const { return ___mTcpServerThread_11; }
	inline Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414 ** get_address_of_mTcpServerThread_11() { return &___mTcpServerThread_11; }
	inline void set_mTcpServerThread_11(Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414 * value)
	{
		___mTcpServerThread_11 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mTcpServerThread_11), (void*)value);
	}

	inline static int32_t get_offset_of_mRegisteredMethods_12() { return static_cast<int32_t>(offsetof(OscServer_tEC9090B8C05007FBB204BE388A8707862015E025, ___mRegisteredMethods_12)); }
	inline List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 * get_mRegisteredMethods_12() const { return ___mRegisteredMethods_12; }
	inline List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 ** get_address_of_mRegisteredMethods_12() { return &___mRegisteredMethods_12; }
	inline void set_mRegisteredMethods_12(List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 * value)
	{
		___mRegisteredMethods_12 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mRegisteredMethods_12), (void*)value);
	}

	inline static int32_t get_offset_of_mFilterRegisteredMethods_13() { return static_cast<int32_t>(offsetof(OscServer_tEC9090B8C05007FBB204BE388A8707862015E025, ___mFilterRegisteredMethods_13)); }
	inline bool get_mFilterRegisteredMethods_13() const { return ___mFilterRegisteredMethods_13; }
	inline bool* get_address_of_mFilterRegisteredMethods_13() { return &___mFilterRegisteredMethods_13; }
	inline void set_mFilterRegisteredMethods_13(bool value)
	{
		___mFilterRegisteredMethods_13 = value;
	}

	inline static int32_t get_offset_of_mTransmissionType_14() { return static_cast<int32_t>(offsetof(OscServer_tEC9090B8C05007FBB204BE388A8707862015E025, ___mTransmissionType_14)); }
	inline int32_t get_mTransmissionType_14() const { return ___mTransmissionType_14; }
	inline int32_t* get_address_of_mTransmissionType_14() { return &___mTransmissionType_14; }
	inline void set_mTransmissionType_14(int32_t value)
	{
		___mTransmissionType_14 = value;
	}

	inline static int32_t get_offset_of_mHandleMessages_15() { return static_cast<int32_t>(offsetof(OscServer_tEC9090B8C05007FBB204BE388A8707862015E025, ___mHandleMessages_15)); }
	inline bool get_mHandleMessages_15() const { return ___mHandleMessages_15; }
	inline bool* get_address_of_mHandleMessages_15() { return &___mHandleMessages_15; }
	inline void set_mHandleMessages_15(bool value)
	{
		___mHandleMessages_15 = value;
	}

	inline static int32_t get_offset_of_mConsumeParsingExceptions_16() { return static_cast<int32_t>(offsetof(OscServer_tEC9090B8C05007FBB204BE388A8707862015E025, ___mConsumeParsingExceptions_16)); }
	inline bool get_mConsumeParsingExceptions_16() const { return ___mConsumeParsingExceptions_16; }
	inline bool* get_address_of_mConsumeParsingExceptions_16() { return &___mConsumeParsingExceptions_16; }
	inline void set_mConsumeParsingExceptions_16(bool value)
	{
		___mConsumeParsingExceptions_16 = value;
	}
};


// System.Net.Sockets.Socket
struct Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09  : public RuntimeObject
{
public:
	// System.Boolean System.Net.Sockets.Socket::is_closed
	bool ___is_closed_10;
	// System.Boolean System.Net.Sockets.Socket::is_listening
	bool ___is_listening_11;
	// System.Boolean System.Net.Sockets.Socket::useOverlappedIO
	bool ___useOverlappedIO_12;
	// System.Int32 System.Net.Sockets.Socket::linger_timeout
	int32_t ___linger_timeout_13;
	// System.Net.Sockets.AddressFamily System.Net.Sockets.Socket::addressFamily
	int32_t ___addressFamily_14;
	// System.Net.Sockets.SocketType System.Net.Sockets.Socket::socketType
	int32_t ___socketType_15;
	// System.Net.Sockets.ProtocolType System.Net.Sockets.Socket::protocolType
	int32_t ___protocolType_16;
	// System.Net.Sockets.SafeSocketHandle System.Net.Sockets.Socket::m_Handle
	SafeSocketHandle_t5050671179FB886DA1763A0E4EFB3FCD072363C9 * ___m_Handle_17;
	// System.Net.EndPoint System.Net.Sockets.Socket::seed_endpoint
	EndPoint_t18D4AE8D03090A2B262136E59F95CE61418C34DA * ___seed_endpoint_18;
	// System.Threading.SemaphoreSlim System.Net.Sockets.Socket::ReadSem
	SemaphoreSlim_t3EF85FC980AE57957BEBB6B78E81DE2E3233D385 * ___ReadSem_19;
	// System.Threading.SemaphoreSlim System.Net.Sockets.Socket::WriteSem
	SemaphoreSlim_t3EF85FC980AE57957BEBB6B78E81DE2E3233D385 * ___WriteSem_20;
	// System.Boolean System.Net.Sockets.Socket::is_blocking
	bool ___is_blocking_21;
	// System.Boolean System.Net.Sockets.Socket::is_bound
	bool ___is_bound_22;
	// System.Boolean System.Net.Sockets.Socket::is_connected
	bool ___is_connected_23;
	// System.Int32 System.Net.Sockets.Socket::m_IntCleanedUp
	int32_t ___m_IntCleanedUp_24;
	// System.Boolean System.Net.Sockets.Socket::connect_in_progress
	bool ___connect_in_progress_25;
	// System.Int32 System.Net.Sockets.Socket::ID
	int32_t ___ID_26;

public:
	inline static int32_t get_offset_of_is_closed_10() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09, ___is_closed_10)); }
	inline bool get_is_closed_10() const { return ___is_closed_10; }
	inline bool* get_address_of_is_closed_10() { return &___is_closed_10; }
	inline void set_is_closed_10(bool value)
	{
		___is_closed_10 = value;
	}

	inline static int32_t get_offset_of_is_listening_11() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09, ___is_listening_11)); }
	inline bool get_is_listening_11() const { return ___is_listening_11; }
	inline bool* get_address_of_is_listening_11() { return &___is_listening_11; }
	inline void set_is_listening_11(bool value)
	{
		___is_listening_11 = value;
	}

	inline static int32_t get_offset_of_useOverlappedIO_12() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09, ___useOverlappedIO_12)); }
	inline bool get_useOverlappedIO_12() const { return ___useOverlappedIO_12; }
	inline bool* get_address_of_useOverlappedIO_12() { return &___useOverlappedIO_12; }
	inline void set_useOverlappedIO_12(bool value)
	{
		___useOverlappedIO_12 = value;
	}

	inline static int32_t get_offset_of_linger_timeout_13() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09, ___linger_timeout_13)); }
	inline int32_t get_linger_timeout_13() const { return ___linger_timeout_13; }
	inline int32_t* get_address_of_linger_timeout_13() { return &___linger_timeout_13; }
	inline void set_linger_timeout_13(int32_t value)
	{
		___linger_timeout_13 = value;
	}

	inline static int32_t get_offset_of_addressFamily_14() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09, ___addressFamily_14)); }
	inline int32_t get_addressFamily_14() const { return ___addressFamily_14; }
	inline int32_t* get_address_of_addressFamily_14() { return &___addressFamily_14; }
	inline void set_addressFamily_14(int32_t value)
	{
		___addressFamily_14 = value;
	}

	inline static int32_t get_offset_of_socketType_15() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09, ___socketType_15)); }
	inline int32_t get_socketType_15() const { return ___socketType_15; }
	inline int32_t* get_address_of_socketType_15() { return &___socketType_15; }
	inline void set_socketType_15(int32_t value)
	{
		___socketType_15 = value;
	}

	inline static int32_t get_offset_of_protocolType_16() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09, ___protocolType_16)); }
	inline int32_t get_protocolType_16() const { return ___protocolType_16; }
	inline int32_t* get_address_of_protocolType_16() { return &___protocolType_16; }
	inline void set_protocolType_16(int32_t value)
	{
		___protocolType_16 = value;
	}

	inline static int32_t get_offset_of_m_Handle_17() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09, ___m_Handle_17)); }
	inline SafeSocketHandle_t5050671179FB886DA1763A0E4EFB3FCD072363C9 * get_m_Handle_17() const { return ___m_Handle_17; }
	inline SafeSocketHandle_t5050671179FB886DA1763A0E4EFB3FCD072363C9 ** get_address_of_m_Handle_17() { return &___m_Handle_17; }
	inline void set_m_Handle_17(SafeSocketHandle_t5050671179FB886DA1763A0E4EFB3FCD072363C9 * value)
	{
		___m_Handle_17 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Handle_17), (void*)value);
	}

	inline static int32_t get_offset_of_seed_endpoint_18() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09, ___seed_endpoint_18)); }
	inline EndPoint_t18D4AE8D03090A2B262136E59F95CE61418C34DA * get_seed_endpoint_18() const { return ___seed_endpoint_18; }
	inline EndPoint_t18D4AE8D03090A2B262136E59F95CE61418C34DA ** get_address_of_seed_endpoint_18() { return &___seed_endpoint_18; }
	inline void set_seed_endpoint_18(EndPoint_t18D4AE8D03090A2B262136E59F95CE61418C34DA * value)
	{
		___seed_endpoint_18 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___seed_endpoint_18), (void*)value);
	}

	inline static int32_t get_offset_of_ReadSem_19() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09, ___ReadSem_19)); }
	inline SemaphoreSlim_t3EF85FC980AE57957BEBB6B78E81DE2E3233D385 * get_ReadSem_19() const { return ___ReadSem_19; }
	inline SemaphoreSlim_t3EF85FC980AE57957BEBB6B78E81DE2E3233D385 ** get_address_of_ReadSem_19() { return &___ReadSem_19; }
	inline void set_ReadSem_19(SemaphoreSlim_t3EF85FC980AE57957BEBB6B78E81DE2E3233D385 * value)
	{
		___ReadSem_19 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___ReadSem_19), (void*)value);
	}

	inline static int32_t get_offset_of_WriteSem_20() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09, ___WriteSem_20)); }
	inline SemaphoreSlim_t3EF85FC980AE57957BEBB6B78E81DE2E3233D385 * get_WriteSem_20() const { return ___WriteSem_20; }
	inline SemaphoreSlim_t3EF85FC980AE57957BEBB6B78E81DE2E3233D385 ** get_address_of_WriteSem_20() { return &___WriteSem_20; }
	inline void set_WriteSem_20(SemaphoreSlim_t3EF85FC980AE57957BEBB6B78E81DE2E3233D385 * value)
	{
		___WriteSem_20 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___WriteSem_20), (void*)value);
	}

	inline static int32_t get_offset_of_is_blocking_21() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09, ___is_blocking_21)); }
	inline bool get_is_blocking_21() const { return ___is_blocking_21; }
	inline bool* get_address_of_is_blocking_21() { return &___is_blocking_21; }
	inline void set_is_blocking_21(bool value)
	{
		___is_blocking_21 = value;
	}

	inline static int32_t get_offset_of_is_bound_22() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09, ___is_bound_22)); }
	inline bool get_is_bound_22() const { return ___is_bound_22; }
	inline bool* get_address_of_is_bound_22() { return &___is_bound_22; }
	inline void set_is_bound_22(bool value)
	{
		___is_bound_22 = value;
	}

	inline static int32_t get_offset_of_is_connected_23() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09, ___is_connected_23)); }
	inline bool get_is_connected_23() const { return ___is_connected_23; }
	inline bool* get_address_of_is_connected_23() { return &___is_connected_23; }
	inline void set_is_connected_23(bool value)
	{
		___is_connected_23 = value;
	}

	inline static int32_t get_offset_of_m_IntCleanedUp_24() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09, ___m_IntCleanedUp_24)); }
	inline int32_t get_m_IntCleanedUp_24() const { return ___m_IntCleanedUp_24; }
	inline int32_t* get_address_of_m_IntCleanedUp_24() { return &___m_IntCleanedUp_24; }
	inline void set_m_IntCleanedUp_24(int32_t value)
	{
		___m_IntCleanedUp_24 = value;
	}

	inline static int32_t get_offset_of_connect_in_progress_25() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09, ___connect_in_progress_25)); }
	inline bool get_connect_in_progress_25() const { return ___connect_in_progress_25; }
	inline bool* get_address_of_connect_in_progress_25() { return &___connect_in_progress_25; }
	inline void set_connect_in_progress_25(bool value)
	{
		___connect_in_progress_25 = value;
	}

	inline static int32_t get_offset_of_ID_26() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09, ___ID_26)); }
	inline int32_t get_ID_26() const { return ___ID_26; }
	inline int32_t* get_address_of_ID_26() { return &___ID_26; }
	inline void set_ID_26(int32_t value)
	{
		___ID_26 = value;
	}
};

struct Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields
{
public:
	// System.Object System.Net.Sockets.Socket::s_InternalSyncObject
	RuntimeObject * ___s_InternalSyncObject_0;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) System.Net.Sockets.Socket::s_SupportsIPv4
	bool ___s_SupportsIPv4_1;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) System.Net.Sockets.Socket::s_SupportsIPv6
	bool ___s_SupportsIPv6_2;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) System.Net.Sockets.Socket::s_OSSupportsIPv6
	bool ___s_OSSupportsIPv6_3;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) System.Net.Sockets.Socket::s_Initialized
	bool ___s_Initialized_4;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) System.Net.Sockets.Socket::s_LoggingEnabled
	bool ___s_LoggingEnabled_5;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) System.Net.Sockets.Socket::s_PerfCountersEnabled
	bool ___s_PerfCountersEnabled_6;
	// System.AsyncCallback System.Net.Sockets.Socket::AcceptAsyncCallback
	AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * ___AcceptAsyncCallback_27;
	// System.IOAsyncCallback System.Net.Sockets.Socket::BeginAcceptCallback
	IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * ___BeginAcceptCallback_28;
	// System.IOAsyncCallback System.Net.Sockets.Socket::BeginAcceptReceiveCallback
	IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * ___BeginAcceptReceiveCallback_29;
	// System.AsyncCallback System.Net.Sockets.Socket::ConnectAsyncCallback
	AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * ___ConnectAsyncCallback_30;
	// System.IOAsyncCallback System.Net.Sockets.Socket::BeginConnectCallback
	IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * ___BeginConnectCallback_31;
	// System.AsyncCallback System.Net.Sockets.Socket::DisconnectAsyncCallback
	AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * ___DisconnectAsyncCallback_32;
	// System.IOAsyncCallback System.Net.Sockets.Socket::BeginDisconnectCallback
	IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * ___BeginDisconnectCallback_33;
	// System.AsyncCallback System.Net.Sockets.Socket::ReceiveAsyncCallback
	AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * ___ReceiveAsyncCallback_34;
	// System.IOAsyncCallback System.Net.Sockets.Socket::BeginReceiveCallback
	IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * ___BeginReceiveCallback_35;
	// System.IOAsyncCallback System.Net.Sockets.Socket::BeginReceiveGenericCallback
	IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * ___BeginReceiveGenericCallback_36;
	// System.AsyncCallback System.Net.Sockets.Socket::ReceiveFromAsyncCallback
	AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * ___ReceiveFromAsyncCallback_37;
	// System.IOAsyncCallback System.Net.Sockets.Socket::BeginReceiveFromCallback
	IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * ___BeginReceiveFromCallback_38;
	// System.AsyncCallback System.Net.Sockets.Socket::SendAsyncCallback
	AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * ___SendAsyncCallback_39;
	// System.IOAsyncCallback System.Net.Sockets.Socket::BeginSendGenericCallback
	IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * ___BeginSendGenericCallback_40;
	// System.AsyncCallback System.Net.Sockets.Socket::SendToAsyncCallback
	AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * ___SendToAsyncCallback_41;

public:
	inline static int32_t get_offset_of_s_InternalSyncObject_0() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___s_InternalSyncObject_0)); }
	inline RuntimeObject * get_s_InternalSyncObject_0() const { return ___s_InternalSyncObject_0; }
	inline RuntimeObject ** get_address_of_s_InternalSyncObject_0() { return &___s_InternalSyncObject_0; }
	inline void set_s_InternalSyncObject_0(RuntimeObject * value)
	{
		___s_InternalSyncObject_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_InternalSyncObject_0), (void*)value);
	}

	inline static int32_t get_offset_of_s_SupportsIPv4_1() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___s_SupportsIPv4_1)); }
	inline bool get_s_SupportsIPv4_1() const { return ___s_SupportsIPv4_1; }
	inline bool* get_address_of_s_SupportsIPv4_1() { return &___s_SupportsIPv4_1; }
	inline void set_s_SupportsIPv4_1(bool value)
	{
		___s_SupportsIPv4_1 = value;
	}

	inline static int32_t get_offset_of_s_SupportsIPv6_2() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___s_SupportsIPv6_2)); }
	inline bool get_s_SupportsIPv6_2() const { return ___s_SupportsIPv6_2; }
	inline bool* get_address_of_s_SupportsIPv6_2() { return &___s_SupportsIPv6_2; }
	inline void set_s_SupportsIPv6_2(bool value)
	{
		___s_SupportsIPv6_2 = value;
	}

	inline static int32_t get_offset_of_s_OSSupportsIPv6_3() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___s_OSSupportsIPv6_3)); }
	inline bool get_s_OSSupportsIPv6_3() const { return ___s_OSSupportsIPv6_3; }
	inline bool* get_address_of_s_OSSupportsIPv6_3() { return &___s_OSSupportsIPv6_3; }
	inline void set_s_OSSupportsIPv6_3(bool value)
	{
		___s_OSSupportsIPv6_3 = value;
	}

	inline static int32_t get_offset_of_s_Initialized_4() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___s_Initialized_4)); }
	inline bool get_s_Initialized_4() const { return ___s_Initialized_4; }
	inline bool* get_address_of_s_Initialized_4() { return &___s_Initialized_4; }
	inline void set_s_Initialized_4(bool value)
	{
		___s_Initialized_4 = value;
	}

	inline static int32_t get_offset_of_s_LoggingEnabled_5() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___s_LoggingEnabled_5)); }
	inline bool get_s_LoggingEnabled_5() const { return ___s_LoggingEnabled_5; }
	inline bool* get_address_of_s_LoggingEnabled_5() { return &___s_LoggingEnabled_5; }
	inline void set_s_LoggingEnabled_5(bool value)
	{
		___s_LoggingEnabled_5 = value;
	}

	inline static int32_t get_offset_of_s_PerfCountersEnabled_6() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___s_PerfCountersEnabled_6)); }
	inline bool get_s_PerfCountersEnabled_6() const { return ___s_PerfCountersEnabled_6; }
	inline bool* get_address_of_s_PerfCountersEnabled_6() { return &___s_PerfCountersEnabled_6; }
	inline void set_s_PerfCountersEnabled_6(bool value)
	{
		___s_PerfCountersEnabled_6 = value;
	}

	inline static int32_t get_offset_of_AcceptAsyncCallback_27() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___AcceptAsyncCallback_27)); }
	inline AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * get_AcceptAsyncCallback_27() const { return ___AcceptAsyncCallback_27; }
	inline AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA ** get_address_of_AcceptAsyncCallback_27() { return &___AcceptAsyncCallback_27; }
	inline void set_AcceptAsyncCallback_27(AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * value)
	{
		___AcceptAsyncCallback_27 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___AcceptAsyncCallback_27), (void*)value);
	}

	inline static int32_t get_offset_of_BeginAcceptCallback_28() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___BeginAcceptCallback_28)); }
	inline IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * get_BeginAcceptCallback_28() const { return ___BeginAcceptCallback_28; }
	inline IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E ** get_address_of_BeginAcceptCallback_28() { return &___BeginAcceptCallback_28; }
	inline void set_BeginAcceptCallback_28(IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * value)
	{
		___BeginAcceptCallback_28 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___BeginAcceptCallback_28), (void*)value);
	}

	inline static int32_t get_offset_of_BeginAcceptReceiveCallback_29() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___BeginAcceptReceiveCallback_29)); }
	inline IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * get_BeginAcceptReceiveCallback_29() const { return ___BeginAcceptReceiveCallback_29; }
	inline IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E ** get_address_of_BeginAcceptReceiveCallback_29() { return &___BeginAcceptReceiveCallback_29; }
	inline void set_BeginAcceptReceiveCallback_29(IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * value)
	{
		___BeginAcceptReceiveCallback_29 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___BeginAcceptReceiveCallback_29), (void*)value);
	}

	inline static int32_t get_offset_of_ConnectAsyncCallback_30() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___ConnectAsyncCallback_30)); }
	inline AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * get_ConnectAsyncCallback_30() const { return ___ConnectAsyncCallback_30; }
	inline AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA ** get_address_of_ConnectAsyncCallback_30() { return &___ConnectAsyncCallback_30; }
	inline void set_ConnectAsyncCallback_30(AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * value)
	{
		___ConnectAsyncCallback_30 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___ConnectAsyncCallback_30), (void*)value);
	}

	inline static int32_t get_offset_of_BeginConnectCallback_31() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___BeginConnectCallback_31)); }
	inline IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * get_BeginConnectCallback_31() const { return ___BeginConnectCallback_31; }
	inline IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E ** get_address_of_BeginConnectCallback_31() { return &___BeginConnectCallback_31; }
	inline void set_BeginConnectCallback_31(IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * value)
	{
		___BeginConnectCallback_31 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___BeginConnectCallback_31), (void*)value);
	}

	inline static int32_t get_offset_of_DisconnectAsyncCallback_32() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___DisconnectAsyncCallback_32)); }
	inline AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * get_DisconnectAsyncCallback_32() const { return ___DisconnectAsyncCallback_32; }
	inline AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA ** get_address_of_DisconnectAsyncCallback_32() { return &___DisconnectAsyncCallback_32; }
	inline void set_DisconnectAsyncCallback_32(AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * value)
	{
		___DisconnectAsyncCallback_32 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___DisconnectAsyncCallback_32), (void*)value);
	}

	inline static int32_t get_offset_of_BeginDisconnectCallback_33() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___BeginDisconnectCallback_33)); }
	inline IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * get_BeginDisconnectCallback_33() const { return ___BeginDisconnectCallback_33; }
	inline IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E ** get_address_of_BeginDisconnectCallback_33() { return &___BeginDisconnectCallback_33; }
	inline void set_BeginDisconnectCallback_33(IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * value)
	{
		___BeginDisconnectCallback_33 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___BeginDisconnectCallback_33), (void*)value);
	}

	inline static int32_t get_offset_of_ReceiveAsyncCallback_34() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___ReceiveAsyncCallback_34)); }
	inline AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * get_ReceiveAsyncCallback_34() const { return ___ReceiveAsyncCallback_34; }
	inline AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA ** get_address_of_ReceiveAsyncCallback_34() { return &___ReceiveAsyncCallback_34; }
	inline void set_ReceiveAsyncCallback_34(AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * value)
	{
		___ReceiveAsyncCallback_34 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___ReceiveAsyncCallback_34), (void*)value);
	}

	inline static int32_t get_offset_of_BeginReceiveCallback_35() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___BeginReceiveCallback_35)); }
	inline IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * get_BeginReceiveCallback_35() const { return ___BeginReceiveCallback_35; }
	inline IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E ** get_address_of_BeginReceiveCallback_35() { return &___BeginReceiveCallback_35; }
	inline void set_BeginReceiveCallback_35(IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * value)
	{
		___BeginReceiveCallback_35 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___BeginReceiveCallback_35), (void*)value);
	}

	inline static int32_t get_offset_of_BeginReceiveGenericCallback_36() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___BeginReceiveGenericCallback_36)); }
	inline IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * get_BeginReceiveGenericCallback_36() const { return ___BeginReceiveGenericCallback_36; }
	inline IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E ** get_address_of_BeginReceiveGenericCallback_36() { return &___BeginReceiveGenericCallback_36; }
	inline void set_BeginReceiveGenericCallback_36(IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * value)
	{
		___BeginReceiveGenericCallback_36 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___BeginReceiveGenericCallback_36), (void*)value);
	}

	inline static int32_t get_offset_of_ReceiveFromAsyncCallback_37() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___ReceiveFromAsyncCallback_37)); }
	inline AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * get_ReceiveFromAsyncCallback_37() const { return ___ReceiveFromAsyncCallback_37; }
	inline AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA ** get_address_of_ReceiveFromAsyncCallback_37() { return &___ReceiveFromAsyncCallback_37; }
	inline void set_ReceiveFromAsyncCallback_37(AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * value)
	{
		___ReceiveFromAsyncCallback_37 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___ReceiveFromAsyncCallback_37), (void*)value);
	}

	inline static int32_t get_offset_of_BeginReceiveFromCallback_38() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___BeginReceiveFromCallback_38)); }
	inline IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * get_BeginReceiveFromCallback_38() const { return ___BeginReceiveFromCallback_38; }
	inline IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E ** get_address_of_BeginReceiveFromCallback_38() { return &___BeginReceiveFromCallback_38; }
	inline void set_BeginReceiveFromCallback_38(IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * value)
	{
		___BeginReceiveFromCallback_38 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___BeginReceiveFromCallback_38), (void*)value);
	}

	inline static int32_t get_offset_of_SendAsyncCallback_39() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___SendAsyncCallback_39)); }
	inline AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * get_SendAsyncCallback_39() const { return ___SendAsyncCallback_39; }
	inline AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA ** get_address_of_SendAsyncCallback_39() { return &___SendAsyncCallback_39; }
	inline void set_SendAsyncCallback_39(AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * value)
	{
		___SendAsyncCallback_39 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___SendAsyncCallback_39), (void*)value);
	}

	inline static int32_t get_offset_of_BeginSendGenericCallback_40() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___BeginSendGenericCallback_40)); }
	inline IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * get_BeginSendGenericCallback_40() const { return ___BeginSendGenericCallback_40; }
	inline IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E ** get_address_of_BeginSendGenericCallback_40() { return &___BeginSendGenericCallback_40; }
	inline void set_BeginSendGenericCallback_40(IOAsyncCallback_tB965FCE75DB2822B784F36808F71EA447D5F977E * value)
	{
		___BeginSendGenericCallback_40 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___BeginSendGenericCallback_40), (void*)value);
	}

	inline static int32_t get_offset_of_SendToAsyncCallback_41() { return static_cast<int32_t>(offsetof(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09_StaticFields, ___SendToAsyncCallback_41)); }
	inline AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * get_SendToAsyncCallback_41() const { return ___SendToAsyncCallback_41; }
	inline AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA ** get_address_of_SendToAsyncCallback_41() { return &___SendToAsyncCallback_41; }
	inline void set_SendToAsyncCallback_41(AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * value)
	{
		___SendToAsyncCallback_41 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___SendToAsyncCallback_41), (void*)value);
	}
};


// System.SystemException
struct SystemException_tC551B4D6EE3772B5F32C71EE8C719F4B43ECCC62  : public Exception_t
{
public:

public:
};


// Bespoke.Common.Net.TcpConnection
struct TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129  : public RuntimeObject
{
public:
	// System.EventHandler`1<Bespoke.Common.Net.TcpConnectionEventArgs> Bespoke.Common.Net.TcpConnection::Disconnected
	EventHandler_1_t3782CAFC23B84FE2565AA899369F210C80E75ECF * ___Disconnected_0;
	// System.EventHandler`1<Bespoke.Common.Net.TcpDataReceivedEventArgs> Bespoke.Common.Net.TcpConnection::DataReceived
	EventHandler_1_tEFAA9D3F682231A3C61310E1CE32DB931BBBAE43 * ___DataReceived_1;
	// System.Net.Sockets.Socket Bespoke.Common.Net.TcpConnection::mClient
	Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09 * ___mClient_3;
	// System.Net.Sockets.NetworkStream Bespoke.Common.Net.TcpConnection::mNetworkStream
	NetworkStream_t160A2538024FE3EC707872435D01F1C20B3B1A48 * ___mNetworkStream_4;
	// System.IO.BinaryReader Bespoke.Common.Net.TcpConnection::mReader
	BinaryReader_t4F45C15FF44F8E1C105704A21FFBE58D60015128 * ___mReader_5;
	// System.IO.BinaryWriter Bespoke.Common.Net.TcpConnection::mWriter
	BinaryWriter_t70074014C7FE27CD9F7500C3F02C4AB61D35554F * ___mWriter_6;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) Bespoke.Common.Net.TcpConnection::mIsClosed
	bool ___mIsClosed_7;
	// System.Boolean Bespoke.Common.Net.TcpConnection::mLittleEndianByteOrder
	bool ___mLittleEndianByteOrder_8;
	// Bespoke.Common.Net.TcpConnection/DataReceiveState Bespoke.Common.Net.TcpConnection::mReceiveState
	int32_t ___mReceiveState_9;
	// System.AsyncCallback Bespoke.Common.Net.TcpConnection::mDataReceivedCallback
	AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * ___mDataReceivedCallback_10;
	// System.Byte[] Bespoke.Common.Net.TcpConnection::mPartiallyReceivedData
	ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___mPartiallyReceivedData_11;
	// System.Collections.Generic.List`1<System.Byte> Bespoke.Common.Net.TcpConnection::mCompletelyReceivedData
	List_1_tD0117BC32B3DBF148E7E9AC108FC376C3D4922CF * ___mCompletelyReceivedData_12;
	// System.Int32 Bespoke.Common.Net.TcpConnection::mMessageLength
	int32_t ___mMessageLength_13;
	// System.Byte[] Bespoke.Common.Net.TcpConnection::mMessageLengthData
	ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___mMessageLengthData_14;
	// System.Int32 Bespoke.Common.Net.TcpConnection::mBytesToProcessRemaining
	int32_t ___mBytesToProcessRemaining_15;

public:
	inline static int32_t get_offset_of_Disconnected_0() { return static_cast<int32_t>(offsetof(TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129, ___Disconnected_0)); }
	inline EventHandler_1_t3782CAFC23B84FE2565AA899369F210C80E75ECF * get_Disconnected_0() const { return ___Disconnected_0; }
	inline EventHandler_1_t3782CAFC23B84FE2565AA899369F210C80E75ECF ** get_address_of_Disconnected_0() { return &___Disconnected_0; }
	inline void set_Disconnected_0(EventHandler_1_t3782CAFC23B84FE2565AA899369F210C80E75ECF * value)
	{
		___Disconnected_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Disconnected_0), (void*)value);
	}

	inline static int32_t get_offset_of_DataReceived_1() { return static_cast<int32_t>(offsetof(TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129, ___DataReceived_1)); }
	inline EventHandler_1_tEFAA9D3F682231A3C61310E1CE32DB931BBBAE43 * get_DataReceived_1() const { return ___DataReceived_1; }
	inline EventHandler_1_tEFAA9D3F682231A3C61310E1CE32DB931BBBAE43 ** get_address_of_DataReceived_1() { return &___DataReceived_1; }
	inline void set_DataReceived_1(EventHandler_1_tEFAA9D3F682231A3C61310E1CE32DB931BBBAE43 * value)
	{
		___DataReceived_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___DataReceived_1), (void*)value);
	}

	inline static int32_t get_offset_of_mClient_3() { return static_cast<int32_t>(offsetof(TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129, ___mClient_3)); }
	inline Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09 * get_mClient_3() const { return ___mClient_3; }
	inline Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09 ** get_address_of_mClient_3() { return &___mClient_3; }
	inline void set_mClient_3(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09 * value)
	{
		___mClient_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mClient_3), (void*)value);
	}

	inline static int32_t get_offset_of_mNetworkStream_4() { return static_cast<int32_t>(offsetof(TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129, ___mNetworkStream_4)); }
	inline NetworkStream_t160A2538024FE3EC707872435D01F1C20B3B1A48 * get_mNetworkStream_4() const { return ___mNetworkStream_4; }
	inline NetworkStream_t160A2538024FE3EC707872435D01F1C20B3B1A48 ** get_address_of_mNetworkStream_4() { return &___mNetworkStream_4; }
	inline void set_mNetworkStream_4(NetworkStream_t160A2538024FE3EC707872435D01F1C20B3B1A48 * value)
	{
		___mNetworkStream_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mNetworkStream_4), (void*)value);
	}

	inline static int32_t get_offset_of_mReader_5() { return static_cast<int32_t>(offsetof(TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129, ___mReader_5)); }
	inline BinaryReader_t4F45C15FF44F8E1C105704A21FFBE58D60015128 * get_mReader_5() const { return ___mReader_5; }
	inline BinaryReader_t4F45C15FF44F8E1C105704A21FFBE58D60015128 ** get_address_of_mReader_5() { return &___mReader_5; }
	inline void set_mReader_5(BinaryReader_t4F45C15FF44F8E1C105704A21FFBE58D60015128 * value)
	{
		___mReader_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mReader_5), (void*)value);
	}

	inline static int32_t get_offset_of_mWriter_6() { return static_cast<int32_t>(offsetof(TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129, ___mWriter_6)); }
	inline BinaryWriter_t70074014C7FE27CD9F7500C3F02C4AB61D35554F * get_mWriter_6() const { return ___mWriter_6; }
	inline BinaryWriter_t70074014C7FE27CD9F7500C3F02C4AB61D35554F ** get_address_of_mWriter_6() { return &___mWriter_6; }
	inline void set_mWriter_6(BinaryWriter_t70074014C7FE27CD9F7500C3F02C4AB61D35554F * value)
	{
		___mWriter_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mWriter_6), (void*)value);
	}

	inline static int32_t get_offset_of_mIsClosed_7() { return static_cast<int32_t>(offsetof(TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129, ___mIsClosed_7)); }
	inline bool get_mIsClosed_7() const { return ___mIsClosed_7; }
	inline bool* get_address_of_mIsClosed_7() { return &___mIsClosed_7; }
	inline void set_mIsClosed_7(bool value)
	{
		___mIsClosed_7 = value;
	}

	inline static int32_t get_offset_of_mLittleEndianByteOrder_8() { return static_cast<int32_t>(offsetof(TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129, ___mLittleEndianByteOrder_8)); }
	inline bool get_mLittleEndianByteOrder_8() const { return ___mLittleEndianByteOrder_8; }
	inline bool* get_address_of_mLittleEndianByteOrder_8() { return &___mLittleEndianByteOrder_8; }
	inline void set_mLittleEndianByteOrder_8(bool value)
	{
		___mLittleEndianByteOrder_8 = value;
	}

	inline static int32_t get_offset_of_mReceiveState_9() { return static_cast<int32_t>(offsetof(TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129, ___mReceiveState_9)); }
	inline int32_t get_mReceiveState_9() const { return ___mReceiveState_9; }
	inline int32_t* get_address_of_mReceiveState_9() { return &___mReceiveState_9; }
	inline void set_mReceiveState_9(int32_t value)
	{
		___mReceiveState_9 = value;
	}

	inline static int32_t get_offset_of_mDataReceivedCallback_10() { return static_cast<int32_t>(offsetof(TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129, ___mDataReceivedCallback_10)); }
	inline AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * get_mDataReceivedCallback_10() const { return ___mDataReceivedCallback_10; }
	inline AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA ** get_address_of_mDataReceivedCallback_10() { return &___mDataReceivedCallback_10; }
	inline void set_mDataReceivedCallback_10(AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * value)
	{
		___mDataReceivedCallback_10 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mDataReceivedCallback_10), (void*)value);
	}

	inline static int32_t get_offset_of_mPartiallyReceivedData_11() { return static_cast<int32_t>(offsetof(TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129, ___mPartiallyReceivedData_11)); }
	inline ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* get_mPartiallyReceivedData_11() const { return ___mPartiallyReceivedData_11; }
	inline ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726** get_address_of_mPartiallyReceivedData_11() { return &___mPartiallyReceivedData_11; }
	inline void set_mPartiallyReceivedData_11(ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* value)
	{
		___mPartiallyReceivedData_11 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mPartiallyReceivedData_11), (void*)value);
	}

	inline static int32_t get_offset_of_mCompletelyReceivedData_12() { return static_cast<int32_t>(offsetof(TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129, ___mCompletelyReceivedData_12)); }
	inline List_1_tD0117BC32B3DBF148E7E9AC108FC376C3D4922CF * get_mCompletelyReceivedData_12() const { return ___mCompletelyReceivedData_12; }
	inline List_1_tD0117BC32B3DBF148E7E9AC108FC376C3D4922CF ** get_address_of_mCompletelyReceivedData_12() { return &___mCompletelyReceivedData_12; }
	inline void set_mCompletelyReceivedData_12(List_1_tD0117BC32B3DBF148E7E9AC108FC376C3D4922CF * value)
	{
		___mCompletelyReceivedData_12 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mCompletelyReceivedData_12), (void*)value);
	}

	inline static int32_t get_offset_of_mMessageLength_13() { return static_cast<int32_t>(offsetof(TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129, ___mMessageLength_13)); }
	inline int32_t get_mMessageLength_13() const { return ___mMessageLength_13; }
	inline int32_t* get_address_of_mMessageLength_13() { return &___mMessageLength_13; }
	inline void set_mMessageLength_13(int32_t value)
	{
		___mMessageLength_13 = value;
	}

	inline static int32_t get_offset_of_mMessageLengthData_14() { return static_cast<int32_t>(offsetof(TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129, ___mMessageLengthData_14)); }
	inline ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* get_mMessageLengthData_14() const { return ___mMessageLengthData_14; }
	inline ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726** get_address_of_mMessageLengthData_14() { return &___mMessageLengthData_14; }
	inline void set_mMessageLengthData_14(ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* value)
	{
		___mMessageLengthData_14 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mMessageLengthData_14), (void*)value);
	}

	inline static int32_t get_offset_of_mBytesToProcessRemaining_15() { return static_cast<int32_t>(offsetof(TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129, ___mBytesToProcessRemaining_15)); }
	inline int32_t get_mBytesToProcessRemaining_15() const { return ___mBytesToProcessRemaining_15; }
	inline int32_t* get_address_of_mBytesToProcessRemaining_15() { return &___mBytesToProcessRemaining_15; }
	inline void set_mBytesToProcessRemaining_15(int32_t value)
	{
		___mBytesToProcessRemaining_15 = value;
	}
};

struct TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129_StaticFields
{
public:
	// System.Int32 Bespoke.Common.Net.TcpConnection::ReceivedDataBufferSize
	int32_t ___ReceivedDataBufferSize_2;

public:
	inline static int32_t get_offset_of_ReceivedDataBufferSize_2() { return static_cast<int32_t>(offsetof(TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129_StaticFields, ___ReceivedDataBufferSize_2)); }
	inline int32_t get_ReceivedDataBufferSize_2() const { return ___ReceivedDataBufferSize_2; }
	inline int32_t* get_address_of_ReceivedDataBufferSize_2() { return &___ReceivedDataBufferSize_2; }
	inline void set_ReceivedDataBufferSize_2(int32_t value)
	{
		___ReceivedDataBufferSize_2 = value;
	}
};


// System.Net.Sockets.UdpClient
struct UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920  : public RuntimeObject
{
public:
	// System.Net.Sockets.Socket System.Net.Sockets.UdpClient::m_ClientSocket
	Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09 * ___m_ClientSocket_1;
	// System.Boolean System.Net.Sockets.UdpClient::m_Active
	bool ___m_Active_2;
	// System.Byte[] System.Net.Sockets.UdpClient::m_Buffer
	ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___m_Buffer_3;
	// System.Net.Sockets.AddressFamily System.Net.Sockets.UdpClient::m_Family
	int32_t ___m_Family_4;
	// System.Boolean System.Net.Sockets.UdpClient::m_CleanedUp
	bool ___m_CleanedUp_5;
	// System.Boolean System.Net.Sockets.UdpClient::m_IsBroadcast
	bool ___m_IsBroadcast_6;

public:
	inline static int32_t get_offset_of_m_ClientSocket_1() { return static_cast<int32_t>(offsetof(UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920, ___m_ClientSocket_1)); }
	inline Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09 * get_m_ClientSocket_1() const { return ___m_ClientSocket_1; }
	inline Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09 ** get_address_of_m_ClientSocket_1() { return &___m_ClientSocket_1; }
	inline void set_m_ClientSocket_1(Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09 * value)
	{
		___m_ClientSocket_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_ClientSocket_1), (void*)value);
	}

	inline static int32_t get_offset_of_m_Active_2() { return static_cast<int32_t>(offsetof(UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920, ___m_Active_2)); }
	inline bool get_m_Active_2() const { return ___m_Active_2; }
	inline bool* get_address_of_m_Active_2() { return &___m_Active_2; }
	inline void set_m_Active_2(bool value)
	{
		___m_Active_2 = value;
	}

	inline static int32_t get_offset_of_m_Buffer_3() { return static_cast<int32_t>(offsetof(UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920, ___m_Buffer_3)); }
	inline ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* get_m_Buffer_3() const { return ___m_Buffer_3; }
	inline ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726** get_address_of_m_Buffer_3() { return &___m_Buffer_3; }
	inline void set_m_Buffer_3(ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* value)
	{
		___m_Buffer_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Buffer_3), (void*)value);
	}

	inline static int32_t get_offset_of_m_Family_4() { return static_cast<int32_t>(offsetof(UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920, ___m_Family_4)); }
	inline int32_t get_m_Family_4() const { return ___m_Family_4; }
	inline int32_t* get_address_of_m_Family_4() { return &___m_Family_4; }
	inline void set_m_Family_4(int32_t value)
	{
		___m_Family_4 = value;
	}

	inline static int32_t get_offset_of_m_CleanedUp_5() { return static_cast<int32_t>(offsetof(UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920, ___m_CleanedUp_5)); }
	inline bool get_m_CleanedUp_5() const { return ___m_CleanedUp_5; }
	inline bool* get_address_of_m_CleanedUp_5() { return &___m_CleanedUp_5; }
	inline void set_m_CleanedUp_5(bool value)
	{
		___m_CleanedUp_5 = value;
	}

	inline static int32_t get_offset_of_m_IsBroadcast_6() { return static_cast<int32_t>(offsetof(UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920, ___m_IsBroadcast_6)); }
	inline bool get_m_IsBroadcast_6() const { return ___m_IsBroadcast_6; }
	inline bool* get_address_of_m_IsBroadcast_6() { return &___m_IsBroadcast_6; }
	inline void set_m_IsBroadcast_6(bool value)
	{
		___m_IsBroadcast_6 = value;
	}
};


// Bespoke.Common.Net.UdpServer
struct UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2  : public IPServer_tBEF36D7D3CD1DEBACE97ACE01D198E4EA25D3C06
{
public:
	// System.EventHandler`1<Bespoke.Common.Net.UdpDataReceivedEventArgs> Bespoke.Common.Net.UdpServer::DataReceived
	EventHandler_1_tEFE51D141A816E328C23211083B6A5CDCAAF1BED * ___DataReceived_0;
	// System.Net.IPAddress Bespoke.Common.Net.UdpServer::mIPAddress
	IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___mIPAddress_1;
	// System.Int32 Bespoke.Common.Net.UdpServer::mPort
	int32_t ___mPort_2;
	// System.Net.IPAddress Bespoke.Common.Net.UdpServer::mMulticastAddress
	IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___mMulticastAddress_3;
	// Bespoke.Common.Net.TransmissionType Bespoke.Common.Net.UdpServer::mTransmissionType
	int32_t ___mTransmissionType_4;
	// System.Net.Sockets.UdpClient Bespoke.Common.Net.UdpServer::mUdpClient
	UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920 * ___mUdpClient_5;
	// System.AsyncCallback Bespoke.Common.Net.UdpServer::mAsynCallback
	AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * ___mAsynCallback_6;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) Bespoke.Common.Net.UdpServer::mAcceptingConnections
	bool ___mAcceptingConnections_7;

public:
	inline static int32_t get_offset_of_DataReceived_0() { return static_cast<int32_t>(offsetof(UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2, ___DataReceived_0)); }
	inline EventHandler_1_tEFE51D141A816E328C23211083B6A5CDCAAF1BED * get_DataReceived_0() const { return ___DataReceived_0; }
	inline EventHandler_1_tEFE51D141A816E328C23211083B6A5CDCAAF1BED ** get_address_of_DataReceived_0() { return &___DataReceived_0; }
	inline void set_DataReceived_0(EventHandler_1_tEFE51D141A816E328C23211083B6A5CDCAAF1BED * value)
	{
		___DataReceived_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___DataReceived_0), (void*)value);
	}

	inline static int32_t get_offset_of_mIPAddress_1() { return static_cast<int32_t>(offsetof(UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2, ___mIPAddress_1)); }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * get_mIPAddress_1() const { return ___mIPAddress_1; }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE ** get_address_of_mIPAddress_1() { return &___mIPAddress_1; }
	inline void set_mIPAddress_1(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * value)
	{
		___mIPAddress_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mIPAddress_1), (void*)value);
	}

	inline static int32_t get_offset_of_mPort_2() { return static_cast<int32_t>(offsetof(UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2, ___mPort_2)); }
	inline int32_t get_mPort_2() const { return ___mPort_2; }
	inline int32_t* get_address_of_mPort_2() { return &___mPort_2; }
	inline void set_mPort_2(int32_t value)
	{
		___mPort_2 = value;
	}

	inline static int32_t get_offset_of_mMulticastAddress_3() { return static_cast<int32_t>(offsetof(UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2, ___mMulticastAddress_3)); }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * get_mMulticastAddress_3() const { return ___mMulticastAddress_3; }
	inline IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE ** get_address_of_mMulticastAddress_3() { return &___mMulticastAddress_3; }
	inline void set_mMulticastAddress_3(IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * value)
	{
		___mMulticastAddress_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mMulticastAddress_3), (void*)value);
	}

	inline static int32_t get_offset_of_mTransmissionType_4() { return static_cast<int32_t>(offsetof(UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2, ___mTransmissionType_4)); }
	inline int32_t get_mTransmissionType_4() const { return ___mTransmissionType_4; }
	inline int32_t* get_address_of_mTransmissionType_4() { return &___mTransmissionType_4; }
	inline void set_mTransmissionType_4(int32_t value)
	{
		___mTransmissionType_4 = value;
	}

	inline static int32_t get_offset_of_mUdpClient_5() { return static_cast<int32_t>(offsetof(UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2, ___mUdpClient_5)); }
	inline UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920 * get_mUdpClient_5() const { return ___mUdpClient_5; }
	inline UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920 ** get_address_of_mUdpClient_5() { return &___mUdpClient_5; }
	inline void set_mUdpClient_5(UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920 * value)
	{
		___mUdpClient_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mUdpClient_5), (void*)value);
	}

	inline static int32_t get_offset_of_mAsynCallback_6() { return static_cast<int32_t>(offsetof(UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2, ___mAsynCallback_6)); }
	inline AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * get_mAsynCallback_6() const { return ___mAsynCallback_6; }
	inline AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA ** get_address_of_mAsynCallback_6() { return &___mAsynCallback_6; }
	inline void set_mAsynCallback_6(AsyncCallback_tA7921BEF974919C46FF8F9D9867C567B200BB0EA * value)
	{
		___mAsynCallback_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___mAsynCallback_6), (void*)value);
	}

	inline static int32_t get_offset_of_mAcceptingConnections_7() { return static_cast<int32_t>(offsetof(UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2, ___mAcceptingConnections_7)); }
	inline bool get_mAcceptingConnections_7() const { return ___mAcceptingConnections_7; }
	inline bool* get_address_of_mAcceptingConnections_7() { return &___mAcceptingConnections_7; }
	inline void set_mAcceptingConnections_7(bool value)
	{
		___mAcceptingConnections_7 = value;
	}
};


// System.EventHandler`1<Bespoke.Common.ExceptionEventArgs>
struct EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F  : public MulticastDelegate_t
{
public:

public:
};


// System.EventHandler`1<Bespoke.Common.Osc.OscBundleReceivedEventArgs>
struct EventHandler_1_t129E585D9AA40035BC8D64CA9AE2FB4166FD9AC4  : public MulticastDelegate_t
{
public:

public:
};


// System.EventHandler`1<Bespoke.Common.Osc.OscMessageReceivedEventArgs>
struct EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714  : public MulticastDelegate_t
{
public:

public:
};


// System.EventHandler`1<Bespoke.Common.Osc.OscPacketReceivedEventArgs>
struct EventHandler_1_t0AFB60D05E9FCFB34BD7F25226CC0CEE2E7271E4  : public MulticastDelegate_t
{
public:

public:
};


// System.EventHandler`1<Bespoke.Common.Net.TcpDataReceivedEventArgs>
struct EventHandler_1_tEFAA9D3F682231A3C61310E1CE32DB931BBBAE43  : public MulticastDelegate_t
{
public:

public:
};


// System.EventHandler`1<Bespoke.Common.Net.UdpDataReceivedEventArgs>
struct EventHandler_1_tEFE51D141A816E328C23211083B6A5CDCAAF1BED  : public MulticastDelegate_t
{
public:

public:
};


// System.InvalidOperationException
struct InvalidOperationException_t10D3EE59AD28EC641ACEE05BCA4271A527E5ECAB  : public SystemException_tC551B4D6EE3772B5F32C71EE8C719F4B43ECCC62
{
public:

public:
};


// System.Threading.ThreadStart
struct ThreadStart_tA13019555BA3CB2B0128F0880760196BF790E687  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// System.Byte[]
struct ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) uint8_t m_Items[1];

public:
	inline uint8_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline uint8_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, uint8_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline uint8_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline uint8_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, uint8_t value)
	{
		m_Items[index] = value;
	}
};
// System.Char[]
struct CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) Il2CppChar m_Items[1];

public:
	inline Il2CppChar GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Il2CppChar* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Il2CppChar value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline Il2CppChar GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Il2CppChar* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Il2CppChar value)
	{
		m_Items[index] = value;
	}
};


// T Bespoke.Common.Osc.OscPacket::ValueFromByteArray<System.Object>(System.Byte[],System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject * OscPacket_ValueFromByteArray_TisRuntimeObject_m0D3E8315E30CA07BE41BD40C2803532EC2A86DD4_gshared (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data0, int32_t* ___start1, const RuntimeMethod* method);
// T Bespoke.Common.Osc.OscPacket::ValueFromByteArray<System.Int32>(System.Byte[],System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t OscPacket_ValueFromByteArray_TisInt32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046_m32A19AD88A6771691E46A055613812D325C93D8A_gshared (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data0, int32_t* ___start1, const RuntimeMethod* method);
// T Bespoke.Common.Osc.OscPacket::ValueFromByteArray<System.Int64>(System.Byte[],System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t OscPacket_ValueFromByteArray_TisInt64_t378EE0D608BD3107E77238E85F30D2BBD46981F3_mC08348CB553E77F8AB350FEFA1FF2E8FFD6C9BFA_gshared (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data0, int32_t* ___start1, const RuntimeMethod* method);
// T Bespoke.Common.Osc.OscPacket::ValueFromByteArray<System.Single>(System.Byte[],System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float OscPacket_ValueFromByteArray_TisSingle_tE07797BA3C98D4CA9B5A19413C19A76688AB899E_mA63BCB726472D5DDB910066AC162C379EDC64645_gshared (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data0, int32_t* ___start1, const RuntimeMethod* method);
// T Bespoke.Common.Osc.OscPacket::ValueFromByteArray<System.Double>(System.Byte[],System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR double OscPacket_ValueFromByteArray_TisDouble_t42821932CB52DE2057E685D0E1AF3DE5033D2181_mCF0D171BA5AD93AF48B22E2341F024AD314EC82B_gshared (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data0, int32_t* ___start1, const RuntimeMethod* method);
// T Bespoke.Common.Osc.OscPacket::ValueFromByteArray<System.Char>(System.Byte[],System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Il2CppChar OscPacket_ValueFromByteArray_TisChar_tFF60D8E7E89A20BE2294A003734341BD1DF43E14_m4A612DEE0C33EEDBF5AEB0708E5E61CDA9D45F62_gshared (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data0, int32_t* ___start1, const RuntimeMethod* method);
// T Bespoke.Common.Osc.OscPacket::ValueFromByteArray<System.Drawing.Color>(System.Byte[],System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334  OscPacket_ValueFromByteArray_TisColor_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334_m2D0F95410365A923A816432EF1F027047CE65238_gshared (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data0, int32_t* ___start1, const RuntimeMethod* method);
// System.Collections.ObjectModel.ReadOnlyCollection`1<!0> System.Collections.Generic.List`1<System.Object>::AsReadOnly()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ReadOnlyCollection_1_t921D1901AD35062BE31FAEB0798A4B814F33A3C3 * List_1_AsReadOnly_m2A562BCF70602A773C266FE3B151E1A56D884F71_gshared (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * __this, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1__ctor_m0F0E00088CF56FEACC9E32D8B7D91B93D91DAA3B_gshared (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * __this, const RuntimeMethod* method);
// System.Void System.EventHandler`1<System.Object>::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EventHandler_1__ctor_m55B15D6747B269625FC10375E6008AA99BD498B4_gshared (EventHandler_1_tFA1C30E54FA1061D79E711F65F9A174BFBD8CDCB * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.List`1<System.Object>::Contains(!0)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool List_1_Contains_m99C700668AC6D272188471D2D6B784A2B5636C8E_gshared (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * __this, RuntimeObject * ___item0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::Add(!0)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1_Add_mE5B3CBB3A625606D9BC4337FEAAF1D66BCB6F96E_gshared (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * __this, RuntimeObject * ___item0, const RuntimeMethod* method);
// System.Void System.EventHandler`1<System.Object>::Invoke(System.Object,!0)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EventHandler_1_Invoke_mEAFD7F9E52E7DF356F3C4F0262BCFBA7769C83C0_gshared (EventHandler_1_tFA1C30E54FA1061D79E711F65F9A174BFBD8CDCB * __this, RuntimeObject * ___sender0, RuntimeObject * ___e1, const RuntimeMethod* method);
// !!0[] Bespoke.Common.Utility::CopySubArray<System.Byte>(!!0[],System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* Utility_CopySubArray_TisByte_t0111FAB8B8685667EDDAF77683F0D8F86B659056_m34AF4999A31EB9E8E03253BAF85132FF9341AC35_gshared (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___source0, int32_t ___start1, int32_t ___length2, const RuntimeMethod* method);

// System.Void Bespoke.Common.Osc.OscPacket::.ctor(System.Net.IPEndPoint,System.String,Bespoke.Common.Osc.OscClient)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscPacket__ctor_m1BD07E88061C178FBB726E239FDE56DA032317D8 (OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * __this, IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___sourceEndPoint0, String_t* ___address1, OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591 * ___client2, const RuntimeMethod* method);
// T Bespoke.Common.Osc.OscPacket::ValueFromByteArray<System.String>(System.Byte[],System.Int32&)
inline String_t* OscPacket_ValueFromByteArray_TisString_t_m0AA6001643C0B3FAAE1B4558B9B77CD82411E198 (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data0, int32_t* ___start1, const RuntimeMethod* method)
{
	return ((  String_t* (*) (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726*, int32_t*, const RuntimeMethod*))OscPacket_ValueFromByteArray_TisRuntimeObject_m0D3E8315E30CA07BE41BD40C2803532EC2A86DD4_gshared)(___data0, ___start1, method);
}
// System.Boolean System.String::op_Equality(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool String_op_Equality_m2B91EE68355F142F67095973D32EB5828B7B73CB (String_t* ___a0, String_t* ___b1, const RuntimeMethod* method);
// System.Void Bespoke.Common.Assert::IsTrue(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Assert_IsTrue_m1ABA281F642FE8A1C9F08DC02CA7B757B5D0C2AE (bool ___condition0, const RuntimeMethod* method);
// T Bespoke.Common.Osc.OscPacket::ValueFromByteArray<Bespoke.Common.Osc.OscTimeTag>(System.Byte[],System.Int32&)
inline OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * OscPacket_ValueFromByteArray_TisOscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_mE6B1E20C5F893E6DC5FBF2E61FB4C54DFF69E7CF (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data0, int32_t* ___start1, const RuntimeMethod* method)
{
	return ((  OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * (*) (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726*, int32_t*, const RuntimeMethod*))OscPacket_ValueFromByteArray_TisRuntimeObject_m0D3E8315E30CA07BE41BD40C2803532EC2A86DD4_gshared)(___data0, ___start1, method);
}
// System.Void Bespoke.Common.Osc.OscBundle::.ctor(System.Net.IPEndPoint,Bespoke.Common.Osc.OscTimeTag,Bespoke.Common.Osc.OscClient)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscBundle__ctor_m7EB8DDB034F7F842B2DFAF585BE6C8F25D77A49C (OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * __this, IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___sourceEndPoint0, OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * ___timeStamp1, OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591 * ___client2, const RuntimeMethod* method);
// T Bespoke.Common.Osc.OscPacket::ValueFromByteArray<System.Int32>(System.Byte[],System.Int32&)
inline int32_t OscPacket_ValueFromByteArray_TisInt32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046_m32A19AD88A6771691E46A055613812D325C93D8A (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data0, int32_t* ___start1, const RuntimeMethod* method)
{
	return ((  int32_t (*) (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726*, int32_t*, const RuntimeMethod*))OscPacket_ValueFromByteArray_TisInt32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046_m32A19AD88A6771691E46A055613812D325C93D8A_gshared)(___data0, ___start1, method);
}
// Bespoke.Common.Osc.OscPacket Bespoke.Common.Osc.OscPacket::FromByteArray(System.Net.IPEndPoint,System.Byte[],System.Int32&,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * OscPacket_FromByteArray_m5366863927BC90527E6510B1118F2D0DF9F31D03 (IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___sourceEndPoint0, ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data1, int32_t* ___start2, int32_t ___end3, const RuntimeMethod* method);
// System.Void System.EventArgs::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EventArgs__ctor_m5ECB9A8ED0A9E2DBB1ED999BAC1CB44F4354E571 (EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA * __this, const RuntimeMethod* method);
// System.Void Bespoke.Common.Assert::ParamIsNotNull(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Assert_ParamIsNotNull_mD80AE1B0A6FE56720DF0480A18BE9C4A7CEBEE70 (RuntimeObject * ___param0, const RuntimeMethod* method);
// System.Boolean System.String::StartsWith(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool String_StartsWith_mDE2FF98CAFFD13F88EDEB6C40158DDF840BFCF12 (String_t* __this, String_t* ___value0, const RuntimeMethod* method);
// System.String System.Char::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Char_ToString_mE0DE433463C56FD30A4F0A50539553B17147C2F8 (Il2CppChar* __this, const RuntimeMethod* method);
// System.Void Bespoke.Common.Osc.OscMessage::.ctor(System.Net.IPEndPoint,System.String,Bespoke.Common.Osc.OscClient)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscMessage__ctor_mA1D568F6D49C1FCD89670DF76F9B00E157965A81 (OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * __this, IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___sourceEndPoint0, String_t* ___address1, OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591 * ___client2, const RuntimeMethod* method);
// System.Char[] System.String::ToCharArray()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34* String_ToCharArray_m33E93AEB7086CBEBDFA5730EAAC49686F144089C (String_t* __this, const RuntimeMethod* method);
// T Bespoke.Common.Osc.OscPacket::ValueFromByteArray<System.Int64>(System.Byte[],System.Int32&)
inline int64_t OscPacket_ValueFromByteArray_TisInt64_t378EE0D608BD3107E77238E85F30D2BBD46981F3_mC08348CB553E77F8AB350FEFA1FF2E8FFD6C9BFA (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data0, int32_t* ___start1, const RuntimeMethod* method)
{
	return ((  int64_t (*) (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726*, int32_t*, const RuntimeMethod*))OscPacket_ValueFromByteArray_TisInt64_t378EE0D608BD3107E77238E85F30D2BBD46981F3_mC08348CB553E77F8AB350FEFA1FF2E8FFD6C9BFA_gshared)(___data0, ___start1, method);
}
// T Bespoke.Common.Osc.OscPacket::ValueFromByteArray<System.Single>(System.Byte[],System.Int32&)
inline float OscPacket_ValueFromByteArray_TisSingle_tE07797BA3C98D4CA9B5A19413C19A76688AB899E_mA63BCB726472D5DDB910066AC162C379EDC64645 (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data0, int32_t* ___start1, const RuntimeMethod* method)
{
	return ((  float (*) (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726*, int32_t*, const RuntimeMethod*))OscPacket_ValueFromByteArray_TisSingle_tE07797BA3C98D4CA9B5A19413C19A76688AB899E_mA63BCB726472D5DDB910066AC162C379EDC64645_gshared)(___data0, ___start1, method);
}
// T Bespoke.Common.Osc.OscPacket::ValueFromByteArray<System.Double>(System.Byte[],System.Int32&)
inline double OscPacket_ValueFromByteArray_TisDouble_t42821932CB52DE2057E685D0E1AF3DE5033D2181_mCF0D171BA5AD93AF48B22E2341F024AD314EC82B (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data0, int32_t* ___start1, const RuntimeMethod* method)
{
	return ((  double (*) (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726*, int32_t*, const RuntimeMethod*))OscPacket_ValueFromByteArray_TisDouble_t42821932CB52DE2057E685D0E1AF3DE5033D2181_mCF0D171BA5AD93AF48B22E2341F024AD314EC82B_gshared)(___data0, ___start1, method);
}
// T Bespoke.Common.Osc.OscPacket::ValueFromByteArray<System.Byte[]>(System.Byte[],System.Int32&)
inline ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* OscPacket_ValueFromByteArray_TisByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726_m1A34F855D9CC53697284E7EFDBBCD4BC64E3E8EE (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data0, int32_t* ___start1, const RuntimeMethod* method)
{
	return ((  ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* (*) (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726*, int32_t*, const RuntimeMethod*))OscPacket_ValueFromByteArray_TisRuntimeObject_m0D3E8315E30CA07BE41BD40C2803532EC2A86DD4_gshared)(___data0, ___start1, method);
}
// T Bespoke.Common.Osc.OscPacket::ValueFromByteArray<System.Char>(System.Byte[],System.Int32&)
inline Il2CppChar OscPacket_ValueFromByteArray_TisChar_tFF60D8E7E89A20BE2294A003734341BD1DF43E14_m4A612DEE0C33EEDBF5AEB0708E5E61CDA9D45F62 (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data0, int32_t* ___start1, const RuntimeMethod* method)
{
	return ((  Il2CppChar (*) (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726*, int32_t*, const RuntimeMethod*))OscPacket_ValueFromByteArray_TisChar_tFF60D8E7E89A20BE2294A003734341BD1DF43E14_m4A612DEE0C33EEDBF5AEB0708E5E61CDA9D45F62_gshared)(___data0, ___start1, method);
}
// T Bespoke.Common.Osc.OscPacket::ValueFromByteArray<System.Drawing.Color>(System.Byte[],System.Int32&)
inline Color_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334  OscPacket_ValueFromByteArray_TisColor_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334_m2D0F95410365A923A816432EF1F027047CE65238 (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data0, int32_t* ___start1, const RuntimeMethod* method)
{
	return ((  Color_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334  (*) (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726*, int32_t*, const RuntimeMethod*))OscPacket_ValueFromByteArray_TisColor_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334_m2D0F95410365A923A816432EF1F027047CE65238_gshared)(___data0, ___start1, method);
}
// System.Collections.ObjectModel.ReadOnlyCollection`1<!0> System.Collections.Generic.List`1<System.Object>::AsReadOnly()
inline ReadOnlyCollection_1_t921D1901AD35062BE31FAEB0798A4B814F33A3C3 * List_1_AsReadOnly_m2A562BCF70602A773C266FE3B151E1A56D884F71 (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * __this, const RuntimeMethod* method)
{
	return ((  ReadOnlyCollection_1_t921D1901AD35062BE31FAEB0798A4B814F33A3C3 * (*) (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 *, const RuntimeMethod*))List_1_AsReadOnly_m2A562BCF70602A773C266FE3B151E1A56D884F71_gshared)(__this, method);
}
// System.Void System.Net.Sockets.UdpClient::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UdpClient__ctor_m2042D1CBDA4D588704EF4828D65C46935B77C778 (UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920 * __this, const RuntimeMethod* method);
// System.Void System.Object::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_m88880E0413421D13FD95325EDCE231707CE1F405 (RuntimeObject * __this, const RuntimeMethod* method);
// System.Boolean System.String::IsNullOrEmpty(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool String_IsNullOrEmpty_m9AFBB5335B441B94E884B8A9D4A27AD60E3D7F7C (String_t* ___value0, const RuntimeMethod* method);
// System.Void Bespoke.Common.Assert::IsFalse(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Assert_IsFalse_mED3CB0B89BCBEB83A4F45840D3CCB20604B7FA80 (bool ___condition0, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.Object>::.ctor()
inline void List_1__ctor_m0F0E00088CF56FEACC9E32D8B7D91B93D91DAA3B (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 *, const RuntimeMethod*))List_1__ctor_m0F0E00088CF56FEACC9E32D8B7D91B93D91DAA3B_gshared)(__this, method);
}
// Bespoke.Common.Osc.OscBundle Bespoke.Common.Osc.OscBundle::FromByteArray(System.Net.IPEndPoint,System.Byte[],System.Int32&,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * OscBundle_FromByteArray_m694F901543F84AA8BA5A0BCD90A777EC57A59E6B (IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___sourceEndPoint0, ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data1, int32_t* ___start2, int32_t ___end3, const RuntimeMethod* method);
// Bespoke.Common.Osc.OscMessage Bespoke.Common.Osc.OscMessage::FromByteArray(System.Net.IPEndPoint,System.Byte[],System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * OscMessage_FromByteArray_m57593CA31720C3B5F75D6D8EAC40E9F284AA2001 (IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___sourceEndPoint0, ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data1, int32_t* ___start2, const RuntimeMethod* method);
// System.Delegate System.Delegate::Combine(System.Delegate,System.Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Delegate_t * Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55 (Delegate_t * ___a0, Delegate_t * ___b1, const RuntimeMethod* method);
// System.Delegate System.Delegate::Remove(System.Delegate,System.Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Delegate_t * Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4 (Delegate_t * ___source0, Delegate_t * ___value1, const RuntimeMethod* method);
// System.Void Bespoke.Common.Osc.OscServer::.ctor(System.Net.TransportType,System.Net.IPAddress,System.Int32,System.Net.IPAddress,Bespoke.Common.Net.TransmissionType,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer__ctor_m498CAB23F18494FEADE8230BBF2977488AA38834 (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, int32_t ___transportType0, IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___ipAddress1, int32_t ___port2, IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___multicastAddress3, int32_t ___transmissionType4, bool ___consumeParsingExceptions5, const RuntimeMethod* method);
// System.Void Bespoke.Common.Net.IPServer::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IPServer__ctor_m83867CDF01D9898FC860351B370DE02B305E568D (IPServer_tBEF36D7D3CD1DEBACE97ACE01D198E4EA25D3C06 * __this, const RuntimeMethod* method);
// System.Void System.InvalidOperationException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InvalidOperationException__ctor_mC012CE552988309733C896F3FEA8249171E4402E (InvalidOperationException_t10D3EE59AD28EC641ACEE05BCA4271A527E5ECAB * __this, String_t* ___message0, const RuntimeMethod* method);
// System.Void System.Net.IPEndPoint::.ctor(System.Net.IPAddress,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IPEndPoint__ctor_m22783A215BA0B38674F6A6CB6803804268561321 (IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * __this, IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___address0, int32_t ___port1, const RuntimeMethod* method);
// System.Void System.Collections.Generic.List`1<System.String>::.ctor()
inline void List_1__ctor_m30C52A4F2828D86CA3FAB0B1B583948F4DA9F1F9 (List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 * __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 *, const RuntimeMethod*))List_1__ctor_m0F0E00088CF56FEACC9E32D8B7D91B93D91DAA3B_gshared)(__this, method);
}
// System.Void Bespoke.Common.Net.UdpServer::.ctor(System.Net.IPAddress,System.Int32,System.Net.IPAddress,Bespoke.Common.Net.TransmissionType)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UdpServer__ctor_mE6D094924DBA73D6CBD181FA0EB6C359B448EB4F (UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2 * __this, IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___ipAddress0, int32_t ___port1, IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___multicastAddress2, int32_t ___transmissionType3, const RuntimeMethod* method);
// System.Void System.EventHandler`1<Bespoke.Common.Net.UdpDataReceivedEventArgs>::.ctor(System.Object,System.IntPtr)
inline void EventHandler_1__ctor_mA440F83BE7D36CF2D080BA620518CCD0B2114A06 (EventHandler_1_tEFE51D141A816E328C23211083B6A5CDCAAF1BED * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	((  void (*) (EventHandler_1_tEFE51D141A816E328C23211083B6A5CDCAAF1BED *, RuntimeObject *, intptr_t, const RuntimeMethod*))EventHandler_1__ctor_m55B15D6747B269625FC10375E6008AA99BD498B4_gshared)(__this, ___object0, ___method1, method);
}
// System.Void Bespoke.Common.Net.UdpServer::add_DataReceived(System.EventHandler`1<Bespoke.Common.Net.UdpDataReceivedEventArgs>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UdpServer_add_DataReceived_mE26DF9A65DE21AAE8FC91E6B79AB13876F9C454C (UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2 * __this, EventHandler_1_tEFE51D141A816E328C23211083B6A5CDCAAF1BED * ___value0, const RuntimeMethod* method);
// System.Boolean Bespoke.Common.Osc.OscPacket::get_LittleEndianByteOrder()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool OscPacket_get_LittleEndianByteOrder_mAD90FE000F92E9C98C43812B33653B589A84AAF1_inline (const RuntimeMethod* method);
// System.Void Bespoke.Common.Net.TcpServer::.ctor(System.Net.IPAddress,System.Int32,System.Boolean,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TcpServer__ctor_m3F2C5B188F93E9A4815993D95FFAFE5F4FE867A9 (TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17 * __this, IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___ipAddress0, int32_t ___port1, bool ___receiveDataInline2, bool ___littleEndianByteOrder3, const RuntimeMethod* method);
// System.Void System.EventHandler`1<Bespoke.Common.Net.TcpDataReceivedEventArgs>::.ctor(System.Object,System.IntPtr)
inline void EventHandler_1__ctor_m8D618A691D600BE62ECACECD277A03C3EFD5B474 (EventHandler_1_tEFAA9D3F682231A3C61310E1CE32DB931BBBAE43 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	((  void (*) (EventHandler_1_tEFAA9D3F682231A3C61310E1CE32DB931BBBAE43 *, RuntimeObject *, intptr_t, const RuntimeMethod*))EventHandler_1__ctor_m55B15D6747B269625FC10375E6008AA99BD498B4_gshared)(__this, ___object0, ___method1, method);
}
// System.Void Bespoke.Common.Net.TcpServer::add_DataReceived(System.EventHandler`1<Bespoke.Common.Net.TcpDataReceivedEventArgs>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TcpServer_add_DataReceived_mEDB155A72C3220CF70350DAAF9ACF197272B5079 (TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17 * __this, EventHandler_1_tEFAA9D3F682231A3C61310E1CE32DB931BBBAE43 * ___value0, const RuntimeMethod* method);
// System.String System.String::Concat(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Concat_m4B4AB72618348C5DFBFBA8DED84B9E2EBDB55E1B (String_t* ___str00, String_t* ___str11, const RuntimeMethod* method);
// System.Void Bespoke.Common.Net.UdpServer::Start()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UdpServer_Start_mFA80E493FFB5BDE21809C7850D598860E5B71E7D (UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2 * __this, const RuntimeMethod* method);
// System.Void System.Threading.ThreadStart::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ThreadStart__ctor_m360F4EED0AD96A27D6A9612BF79671F26B30411F (ThreadStart_tA13019555BA3CB2B0128F0880760196BF790E687 * __this, RuntimeObject * ___object0, intptr_t ___method1, const RuntimeMethod* method);
// System.Void System.Threading.Thread::.ctor(System.Threading.ThreadStart)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Thread__ctor_mF22465F0D0E47C11EF25DB552D1047402750BE90 (Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414 * __this, ThreadStart_tA13019555BA3CB2B0128F0880760196BF790E687 * ___start0, const RuntimeMethod* method);
// System.Void System.Threading.Thread::set_Name(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Thread_set_Name_m920049DFD1306F42613F13CF7AD74C03661F4BAE (Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414 * __this, String_t* ___value0, const RuntimeMethod* method);
// System.Void System.Threading.Thread::Start()
IL2CPP_EXTERN_C IL2CPP_NO_INLINE IL2CPP_METHOD_ATTR void Thread_Start_m490124B23F5EFD0BB2BED8CA12C77195B9CD9E1B (Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414 * __this, const RuntimeMethod* method);
// System.Boolean System.Collections.Generic.List`1<System.String>::Contains(!0)
inline bool List_1_Contains_m2EAD2DADA0478175052301E48FCE772ECD9A6F5F (List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 * __this, String_t* ___item0, const RuntimeMethod* method)
{
	return ((  bool (*) (List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 *, String_t*, const RuntimeMethod*))List_1_Contains_m99C700668AC6D272188471D2D6B784A2B5636C8E_gshared)(__this, ___item0, method);
}
// System.Void System.Collections.Generic.List`1<System.String>::Add(!0)
inline void List_1_Add_m627ED3F7C50096BB8934F778CB980E79483BD2AE (List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 * __this, String_t* ___item0, const RuntimeMethod* method)
{
	((  void (*) (List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 *, String_t*, const RuntimeMethod*))List_1_Add_mE5B3CBB3A625606D9BC4337FEAAF1D66BCB6F96E_gshared)(__this, ___item0, method);
}
// System.Net.IPEndPoint Bespoke.Common.Net.UdpDataReceivedEventArgs::get_SourceEndPoint()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * UdpDataReceivedEventArgs_get_SourceEndPoint_mED1CFBC4279CE8D12B4FE602FF2CBAA4B84739B5_inline (UdpDataReceivedEventArgs_t148E7E67B81BD9271877379526876EBCA1A0B7F0 * __this, const RuntimeMethod* method);
// System.Byte[] Bespoke.Common.Net.UdpDataReceivedEventArgs::get_Data()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* UdpDataReceivedEventArgs_get_Data_mBC575440F2AD896A6FA31CF042BF2B2559CBC832_inline (UdpDataReceivedEventArgs_t148E7E67B81BD9271877379526876EBCA1A0B7F0 * __this, const RuntimeMethod* method);
// System.Void Bespoke.Common.Osc.OscServer::DataReceived(System.Net.IPEndPoint,System.Byte[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer_DataReceived_m911BC3E54D091A851D1DAB3FFB70444BBF47D64E (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___sourceEndPoint0, ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data1, const RuntimeMethod* method);
// Bespoke.Common.Net.TcpConnection Bespoke.Common.Net.TcpDataReceivedEventArgs::get_Connection()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129 * TcpDataReceivedEventArgs_get_Connection_m3E0F9BB18CE66DFC5AB97837917E6AF2033F040C_inline (TcpDataReceivedEventArgs_t2A59DD027A324B15BAE90E0AC00122E825EDF4B3 * __this, const RuntimeMethod* method);
// System.Net.Sockets.Socket Bespoke.Common.Net.TcpConnection::get_Client()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09 * TcpConnection_get_Client_m1105A1E357094D0B4306B0BCA740CAB6609D3DB7_inline (TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129 * __this, const RuntimeMethod* method);
// System.Net.EndPoint System.Net.Sockets.Socket::get_RemoteEndPoint()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR EndPoint_t18D4AE8D03090A2B262136E59F95CE61418C34DA * Socket_get_RemoteEndPoint_m262E08E8CD25A908CB87450FC73683AB9DF636A7 (Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09 * __this, const RuntimeMethod* method);
// System.Byte[] Bespoke.Common.Net.TcpDataReceivedEventArgs::get_Data()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* TcpDataReceivedEventArgs_get_Data_m309F675CADCD367023442B21705B2D4E70851769_inline (TcpDataReceivedEventArgs_t2A59DD027A324B15BAE90E0AC00122E825EDF4B3 * __this, const RuntimeMethod* method);
// Bespoke.Common.Osc.OscPacket Bespoke.Common.Osc.OscPacket::FromByteArray(System.Net.IPEndPoint,System.Byte[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * OscPacket_FromByteArray_mF4ADF635CE40A8B3A3D1BFD76C69292817E94320 (IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___sourceEndPoint0, ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data1, const RuntimeMethod* method);
// System.Void Bespoke.Common.Osc.OscServer::OnPacketReceived(Bespoke.Common.Osc.OscPacket)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer_OnPacketReceived_m860D1520295C31E85D109BAA3DAD84506A3F273E (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * ___packet0, const RuntimeMethod* method);
// System.Void Bespoke.Common.Osc.OscServer::OnBundleReceived(Bespoke.Common.Osc.OscBundle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer_OnBundleReceived_mF7A7CD601531F774FD91AFB8B96FD66703348D63 (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * ___bundle0, const RuntimeMethod* method);
// System.String Bespoke.Common.Osc.OscPacket::get_Address()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR String_t* OscPacket_get_Address_mD45518659033C523F1F8B38447C0FA5F52B3C1B5_inline (OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * __this, const RuntimeMethod* method);
// System.Void Bespoke.Common.Osc.OscServer::OnMessageReceived(Bespoke.Common.Osc.OscMessage)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer_OnMessageReceived_m86B75EBC89384DA4515224BCE58FBF7F39940E9B (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * ___message0, const RuntimeMethod* method);
// System.Void Bespoke.Common.Osc.OscServer::OnReceiveErrored(System.Exception)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer_OnReceiveErrored_m5131D10379E290CEB442E918C058D9140F2F257E (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, Exception_t * ___ex0, const RuntimeMethod* method);
// System.Void Bespoke.Common.Osc.OscPacketReceivedEventArgs::.ctor(Bespoke.Common.Osc.OscPacket)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscPacketReceivedEventArgs__ctor_mCBE38234059260263BE854F6BC0528E4456189FF (OscPacketReceivedEventArgs_t61CB29F943015645037B535D6348EA15E19C680B * __this, OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * ___packet0, const RuntimeMethod* method);
// System.Void System.EventHandler`1<Bespoke.Common.Osc.OscPacketReceivedEventArgs>::Invoke(System.Object,!0)
inline void EventHandler_1_Invoke_mE2206F76F47AF2795139FCA29519AA990016BEC4 (EventHandler_1_t0AFB60D05E9FCFB34BD7F25226CC0CEE2E7271E4 * __this, RuntimeObject * ___sender0, OscPacketReceivedEventArgs_t61CB29F943015645037B535D6348EA15E19C680B * ___e1, const RuntimeMethod* method)
{
	((  void (*) (EventHandler_1_t0AFB60D05E9FCFB34BD7F25226CC0CEE2E7271E4 *, RuntimeObject *, OscPacketReceivedEventArgs_t61CB29F943015645037B535D6348EA15E19C680B *, const RuntimeMethod*))EventHandler_1_Invoke_mEAFD7F9E52E7DF356F3C4F0262BCFBA7769C83C0_gshared)(__this, ___sender0, ___e1, method);
}
// System.Void Bespoke.Common.Osc.OscBundleReceivedEventArgs::.ctor(Bespoke.Common.Osc.OscBundle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscBundleReceivedEventArgs__ctor_m6F728FD0758DC5D906D5EA29E795A90445005355 (OscBundleReceivedEventArgs_t1ABF2F51A974BCF1B4328DCA66A094C2D6AB6345 * __this, OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * ___bundle0, const RuntimeMethod* method);
// System.Void System.EventHandler`1<Bespoke.Common.Osc.OscBundleReceivedEventArgs>::Invoke(System.Object,!0)
inline void EventHandler_1_Invoke_m9FBD0C6547BE3E0181C257B21FC575BF296A5205 (EventHandler_1_t129E585D9AA40035BC8D64CA9AE2FB4166FD9AC4 * __this, RuntimeObject * ___sender0, OscBundleReceivedEventArgs_t1ABF2F51A974BCF1B4328DCA66A094C2D6AB6345 * ___e1, const RuntimeMethod* method)
{
	((  void (*) (EventHandler_1_t129E585D9AA40035BC8D64CA9AE2FB4166FD9AC4 *, RuntimeObject *, OscBundleReceivedEventArgs_t1ABF2F51A974BCF1B4328DCA66A094C2D6AB6345 *, const RuntimeMethod*))EventHandler_1_Invoke_mEAFD7F9E52E7DF356F3C4F0262BCFBA7769C83C0_gshared)(__this, ___sender0, ___e1, method);
}
// System.Collections.Generic.IList`1<System.Object> Bespoke.Common.Osc.OscPacket::get_Data()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* OscPacket_get_Data_mD670EFFAF7A2F1D60A157BB958512515DAAF92FA (OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * __this, const RuntimeMethod* method);
// System.Void Bespoke.Common.Osc.OscMessageReceivedEventArgs::.ctor(Bespoke.Common.Osc.OscMessage)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscMessageReceivedEventArgs__ctor_mFDDFFCCE818650EE040AB7BF15C2D2B24945C84B (OscMessageReceivedEventArgs_t8E8CE6EC7E84AF0892F400AB363313C22B8C4E83 * __this, OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * ___message0, const RuntimeMethod* method);
// System.Void System.EventHandler`1<Bespoke.Common.Osc.OscMessageReceivedEventArgs>::Invoke(System.Object,!0)
inline void EventHandler_1_Invoke_mC992C9DD6820DCE0E81AC4354254266855395E44 (EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * __this, RuntimeObject * ___sender0, OscMessageReceivedEventArgs_t8E8CE6EC7E84AF0892F400AB363313C22B8C4E83 * ___e1, const RuntimeMethod* method)
{
	((  void (*) (EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 *, RuntimeObject *, OscMessageReceivedEventArgs_t8E8CE6EC7E84AF0892F400AB363313C22B8C4E83 *, const RuntimeMethod*))EventHandler_1_Invoke_mEAFD7F9E52E7DF356F3C4F0262BCFBA7769C83C0_gshared)(__this, ___sender0, ___e1, method);
}
// System.Void Bespoke.Common.ExceptionEventArgs::.ctor(System.Exception)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ExceptionEventArgs__ctor_mB5208F480F27F45719DBEC4931AC356B7FE222AA (ExceptionEventArgs_t1207BC0BED111D8BEA61607413C2A139F8A1DDC0 * __this, Exception_t * ___ex0, const RuntimeMethod* method);
// System.Void System.EventHandler`1<Bespoke.Common.ExceptionEventArgs>::Invoke(System.Object,!0)
inline void EventHandler_1_Invoke_mDAF40BCF69918DFB2E3A7C5006658EBD7B6DFA22 (EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * __this, RuntimeObject * ___sender0, ExceptionEventArgs_t1207BC0BED111D8BEA61607413C2A139F8A1DDC0 * ___e1, const RuntimeMethod* method)
{
	((  void (*) (EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F *, RuntimeObject *, ExceptionEventArgs_t1207BC0BED111D8BEA61607413C2A139F8A1DDC0 *, const RuntimeMethod*))EventHandler_1_Invoke_mEAFD7F9E52E7DF356F3C4F0262BCFBA7769C83C0_gshared)(__this, ___sender0, ___e1, method);
}
// System.Void Bespoke.Common.Osc.OscTimeTag::Set(System.DateTime)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscTimeTag_Set_m7B9425997597C968F6C96307FF720A29946F6C4A (OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * __this, DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  ___timeStamp0, const RuntimeMethod* method);
// !!0[] Bespoke.Common.Utility::CopySubArray<System.Byte>(!!0[],System.Int32,System.Int32)
inline ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* Utility_CopySubArray_TisByte_t0111FAB8B8685667EDDAF77683F0D8F86B659056_m34AF4999A31EB9E8E03253BAF85132FF9341AC35 (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___source0, int32_t ___start1, int32_t ___length2, const RuntimeMethod* method)
{
	return ((  ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* (*) (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726*, int32_t, int32_t, const RuntimeMethod*))Utility_CopySubArray_TisByte_t0111FAB8B8685667EDDAF77683F0D8F86B659056_m34AF4999A31EB9E8E03253BAF85132FF9341AC35_gshared)(___source0, ___start1, ___length2, method);
}
// System.Byte[] Bespoke.Common.Utility::SwapEndian(System.Byte[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* Utility_SwapEndian_mFE91837F95B070E0A498234341F4613EB00F11B1 (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data0, const RuntimeMethod* method);
// System.UInt32 System.BitConverter::ToUInt32(System.Byte[],System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t BitConverter_ToUInt32_m0C9F3D9840110CC82D4C18FD882AC5C7EA595366 (ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___value0, int32_t ___startIndex1, const RuntimeMethod* method);
// System.DateTime System.DateTime::AddSeconds(System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  DateTime_AddSeconds_mCA0940A7E7C3ED40A86532349B7D4CB3A0F0DEAF (DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 * __this, double ___value0, const RuntimeMethod* method);
// System.DateTime System.DateTime::AddMilliseconds(System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  DateTime_AddMilliseconds_m74B689CDAFB7ABEEF56827D8777B7C95C89C3154 (DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 * __this, double ___value0, const RuntimeMethod* method);
// System.Boolean Bespoke.Common.Osc.OscTimeTag::IsValidTime(System.DateTime)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool OscTimeTag_IsValidTime_m6F67C8A47A42584D6F8F1D61E5AAECB5E3BC6489 (DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  ___timeStamp0, const RuntimeMethod* method);
// System.DateTime Bespoke.Common.Osc.OscTimeTag::get_DateTime()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  OscTimeTag_get_DateTime_mAD491347C2C6C24AA2FC6B03E263683756EFDF25_inline (OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * __this, const RuntimeMethod* method);
// System.Boolean System.DateTime::op_Equality(System.DateTime,System.DateTime)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool DateTime_op_Equality_m07957AECB8C66EA047B16511BF560DD9EDA1DA44 (DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  ___d10, DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  ___d21, const RuntimeMethod* method);
// System.Boolean System.DateTime::op_GreaterThanOrEqual(System.DateTime,System.DateTime)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool DateTime_op_GreaterThanOrEqual_mB7C78A9E8E0004F447A9E2735FB33E20005C96C0 (DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  ___t10, DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  ___t21, const RuntimeMethod* method);
// System.TimeSpan System.TimeSpan::FromMilliseconds(System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203  TimeSpan_FromMilliseconds_m12D90542B044C450FDFBCEA1CBC32369479483EC (double ___value0, const RuntimeMethod* method);
// System.DateTime System.DateTime::op_Addition(System.DateTime,System.TimeSpan)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  DateTime_op_Addition_m7EDD5204F9E1BCE2C13DE0064417BCA04418BC14 (DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  ___d0, TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203  ___t1, const RuntimeMethod* method);
// System.Int64 System.DateTime::get_Ticks()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t DateTime_get_Ticks_m175EDB41A50DB06872CC48CAB603FEBD1DFF46A9 (DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 * __this, const RuntimeMethod* method);
// System.DateTimeKind System.DateTime::get_Kind()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t DateTime_get_Kind_mC7EC1A788CC9A875094117214C5A0C153A39F496 (DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 * __this, const RuntimeMethod* method);
// System.Void System.DateTime::.ctor(System.Int64,System.DateTimeKind)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DateTime__ctor_mD17BC147184B06220C3FD44EBF50238A3894ADD7 (DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 * __this, int64_t ___ticks0, int32_t ___kind1, const RuntimeMethod* method);
// System.Boolean Bespoke.Common.Osc.OscTimeTag::op_Equality(Bespoke.Common.Osc.OscTimeTag,Bespoke.Common.Osc.OscTimeTag)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool OscTimeTag_op_Equality_m65F04723AA02BAEE8D919C71053C0968633DF730 (OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * ___lhs0, OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * ___rhs1, const RuntimeMethod* method);
// System.Boolean System.DateTime::Equals(System.DateTime)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool DateTime_Equals_m22392E29066D685DB7DD20CB022B101E0CC244EA (DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 * __this, DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  ___value0, const RuntimeMethod* method);
// System.Int32 System.DateTime::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t DateTime_GetHashCode_mC94DC52667BB5C0DE7A78C53BE24FDF5469BA49D (DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 * __this, const RuntimeMethod* method);
// System.String System.DateTime::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* DateTime_ToString_m242888E500DFD8CD675BDC455BC696AF47813954 (DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 * __this, const RuntimeMethod* method);
// System.Void System.DateTime::.ctor(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DateTime__ctor_m0FFFFEA32E380156E1FB4224D50CD0B16707E61C (DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 * __this, int32_t ___year0, int32_t ___month1, int32_t ___day2, int32_t ___hour3, int32_t ___minute4, int32_t ___second5, int32_t ___millisecond6, const RuntimeMethod* method);
// System.Void Bespoke.Common.Osc.OscTimeTag::.ctor(System.DateTime)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscTimeTag__ctor_mCB193BCB3F611E61B03FE5FEFF2791B367B5CE61 (OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * __this, DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  ___timeStamp0, const RuntimeMethod* method);
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Boolean Bespoke.Common.Osc.OscBundle::get_IsBundle()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool OscBundle_get_IsBundle_m8AC8F63514E23F4F63B1394B245B19B5921D60DF (OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * __this, const RuntimeMethod* method)
{
	{
		return (bool)1;
	}
}
// System.Void Bespoke.Common.Osc.OscBundle::.ctor(System.Net.IPEndPoint,Bespoke.Common.Osc.OscTimeTag,Bespoke.Common.Osc.OscClient)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscBundle__ctor_m7EB8DDB034F7F842B2DFAF585BE6C8F25D77A49C (OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * __this, IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___sourceEndPoint0, OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * ___timeStamp1, OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591 * ___client2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral41F9662AC67058AED0D7122A99991B3220ED038D);
		s_Il2CppMethodInitialized = true;
	}
	{
		IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * L_0 = ___sourceEndPoint0;
		OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591 * L_1 = ___client2;
		IL2CPP_RUNTIME_CLASS_INIT(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		OscPacket__ctor_m1BD07E88061C178FBB726E239FDE56DA032317D8(__this, L_0, _stringLiteral41F9662AC67058AED0D7122A99991B3220ED038D, L_1, /*hidden argument*/NULL);
		OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * L_2 = ___timeStamp1;
		__this->set_mTimeStamp_7(L_2);
		return;
	}
}
// Bespoke.Common.Osc.OscBundle Bespoke.Common.Osc.OscBundle::FromByteArray(System.Net.IPEndPoint,System.Byte[],System.Int32&,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * OscBundle_FromByteArray_m694F901543F84AA8BA5A0BCD90A777EC57A59E6B (IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___sourceEndPoint0, ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data1, int32_t* ___start2, int32_t ___end3, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_Append_TisOscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_m71375CEDD55045937DA18D10DE08B4FC26398809_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_ValueFromByteArray_TisInt32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046_m32A19AD88A6771691E46A055613812D325C93D8A_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_ValueFromByteArray_TisOscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_mE6B1E20C5F893E6DC5FBF2E61FB4C54DFF69E7CF_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_ValueFromByteArray_TisString_t_m0AA6001643C0B3FAAE1B4558B9B77CD82411E198_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral41F9662AC67058AED0D7122A99991B3220ED038D);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * V_1 = NULL;
	OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * V_2 = NULL;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	{
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_0 = ___data1;
		int32_t* L_1 = ___start2;
		IL2CPP_RUNTIME_CLASS_INIT(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		String_t* L_2;
		L_2 = OscPacket_ValueFromByteArray_TisString_t_m0AA6001643C0B3FAAE1B4558B9B77CD82411E198(L_0, (int32_t*)L_1, /*hidden argument*/OscPacket_ValueFromByteArray_TisString_t_m0AA6001643C0B3FAAE1B4558B9B77CD82411E198_RuntimeMethod_var);
		V_0 = L_2;
		String_t* L_3 = V_0;
		bool L_4;
		L_4 = String_op_Equality_m2B91EE68355F142F67095973D32EB5828B7B73CB(L_3, _stringLiteral41F9662AC67058AED0D7122A99991B3220ED038D, /*hidden argument*/NULL);
		Assert_IsTrue_m1ABA281F642FE8A1C9F08DC02CA7B757B5D0C2AE(L_4, /*hidden argument*/NULL);
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_5 = ___data1;
		int32_t* L_6 = ___start2;
		OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * L_7;
		L_7 = OscPacket_ValueFromByteArray_TisOscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_mE6B1E20C5F893E6DC5FBF2E61FB4C54DFF69E7CF(L_5, (int32_t*)L_6, /*hidden argument*/OscPacket_ValueFromByteArray_TisOscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_mE6B1E20C5F893E6DC5FBF2E61FB4C54DFF69E7CF_RuntimeMethod_var);
		V_1 = L_7;
		IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * L_8 = ___sourceEndPoint0;
		OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * L_9 = V_1;
		OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * L_10 = (OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 *)il2cpp_codegen_object_new(OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41_il2cpp_TypeInfo_var);
		OscBundle__ctor_m7EB8DDB034F7F842B2DFAF585BE6C8F25D77A49C(L_10, L_8, L_9, (OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591 *)NULL, /*hidden argument*/NULL);
		V_2 = L_10;
		goto IL_004a;
	}

IL_002b:
	{
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_11 = ___data1;
		int32_t* L_12 = ___start2;
		IL2CPP_RUNTIME_CLASS_INIT(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		int32_t L_13;
		L_13 = OscPacket_ValueFromByteArray_TisInt32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046_m32A19AD88A6771691E46A055613812D325C93D8A(L_11, (int32_t*)L_12, /*hidden argument*/OscPacket_ValueFromByteArray_TisInt32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046_m32A19AD88A6771691E46A055613812D325C93D8A_RuntimeMethod_var);
		V_3 = L_13;
		int32_t* L_14 = ___start2;
		int32_t L_15 = *((int32_t*)L_14);
		int32_t L_16 = V_3;
		V_4 = ((int32_t)il2cpp_codegen_add((int32_t)L_15, (int32_t)L_16));
		OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * L_17 = V_2;
		IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * L_18 = ___sourceEndPoint0;
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_19 = ___data1;
		int32_t* L_20 = ___start2;
		int32_t L_21 = V_4;
		OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * L_22;
		L_22 = OscPacket_FromByteArray_m5366863927BC90527E6510B1118F2D0DF9F31D03(L_18, L_19, (int32_t*)L_20, L_21, /*hidden argument*/NULL);
		NullCheck(L_17);
		int32_t L_23;
		L_23 = GenericVirtFuncInvoker1< int32_t, OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * >::Invoke(OscPacket_Append_TisOscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_m71375CEDD55045937DA18D10DE08B4FC26398809_RuntimeMethod_var, L_17, L_22);
	}

IL_004a:
	{
		int32_t* L_24 = ___start2;
		int32_t L_25 = *((int32_t*)L_24);
		int32_t L_26 = ___end3;
		if ((((int32_t)L_25) < ((int32_t)L_26)))
		{
			goto IL_002b;
		}
	}
	{
		OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * L_27 = V_2;
		return L_27;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Bespoke.Common.Osc.OscBundleReceivedEventArgs::.ctor(Bespoke.Common.Osc.OscBundle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscBundleReceivedEventArgs__ctor_m6F728FD0758DC5D906D5EA29E795A90445005355 (OscBundleReceivedEventArgs_t1ABF2F51A974BCF1B4328DCA66A094C2D6AB6345 * __this, OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * ___bundle0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA_il2cpp_TypeInfo_var);
		EventArgs__ctor_m5ECB9A8ED0A9E2DBB1ED999BAC1CB44F4354E571(__this, /*hidden argument*/NULL);
		OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * L_0 = ___bundle0;
		Assert_ParamIsNotNull_mD80AE1B0A6FE56720DF0480A18BE9C4A7CEBEE70(L_0, /*hidden argument*/NULL);
		OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * L_1 = ___bundle0;
		__this->set_mBundle_1(L_1);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Boolean Bespoke.Common.Osc.OscMessage::get_IsBundle()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool OscMessage_get_IsBundle_m47008C70624AC1F44F5237A9BED8639C0B81BD1B (OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * __this, const RuntimeMethod* method)
{
	{
		return (bool)0;
	}
}
// System.Void Bespoke.Common.Osc.OscMessage::.ctor(System.Net.IPEndPoint,System.String,Bespoke.Common.Osc.OscClient)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscMessage__ctor_mA1D568F6D49C1FCD89670DF76F9B00E157965A81 (OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * __this, IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___sourceEndPoint0, String_t* ___address1, OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591 * ___client2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral86BBAACC00198DBB3046818AD3FC2AA10AE48DE1);
		s_Il2CppMethodInitialized = true;
	}
	Il2CppChar V_0 = 0x0;
	{
		IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * L_0 = ___sourceEndPoint0;
		String_t* L_1 = ___address1;
		OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591 * L_2 = ___client2;
		IL2CPP_RUNTIME_CLASS_INIT(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		OscPacket__ctor_m1BD07E88061C178FBB726E239FDE56DA032317D8(__this, L_0, L_1, L_2, /*hidden argument*/NULL);
		String_t* L_3 = ___address1;
		NullCheck(L_3);
		bool L_4;
		L_4 = String_StartsWith_mDE2FF98CAFFD13F88EDEB6C40158DDF840BFCF12(L_3, _stringLiteral86BBAACC00198DBB3046818AD3FC2AA10AE48DE1, /*hidden argument*/NULL);
		Assert_IsTrue_m1ABA281F642FE8A1C9F08DC02CA7B757B5D0C2AE(L_4, /*hidden argument*/NULL);
		V_0 = ((int32_t)44);
		String_t* L_5;
		L_5 = Char_ToString_mE0DE433463C56FD30A4F0A50539553B17147C2F8((Il2CppChar*)(&V_0), /*hidden argument*/NULL);
		__this->set_mTypeTag_22(L_5);
		return;
	}
}
// Bespoke.Common.Osc.OscMessage Bespoke.Common.Osc.OscMessage::FromByteArray(System.Net.IPEndPoint,System.Byte[],System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * OscMessage_FromByteArray_m57593CA31720C3B5F75D6D8EAC40E9F284AA2001 (IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___sourceEndPoint0, ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data1, int32_t* ___start2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Char_tFF60D8E7E89A20BE2294A003734341BD1DF43E14_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Color_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_t42821932CB52DE2057E685D0E1AF3DE5033D2181_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t378EE0D608BD3107E77238E85F30D2BBD46981F3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_Append_TisRuntimeObject_mC8350C70C82033B5A4E83A2F005E6D173918DEA6_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_ValueFromByteArray_TisByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726_m1A34F855D9CC53697284E7EFDBBCD4BC64E3E8EE_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_ValueFromByteArray_TisChar_tFF60D8E7E89A20BE2294A003734341BD1DF43E14_m4A612DEE0C33EEDBF5AEB0708E5E61CDA9D45F62_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_ValueFromByteArray_TisColor_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334_m2D0F95410365A923A816432EF1F027047CE65238_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_ValueFromByteArray_TisDouble_t42821932CB52DE2057E685D0E1AF3DE5033D2181_mCF0D171BA5AD93AF48B22E2341F024AD314EC82B_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_ValueFromByteArray_TisInt32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046_m32A19AD88A6771691E46A055613812D325C93D8A_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_ValueFromByteArray_TisInt64_t378EE0D608BD3107E77238E85F30D2BBD46981F3_mC08348CB553E77F8AB350FEFA1FF2E8FFD6C9BFA_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_ValueFromByteArray_TisOscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_mE6B1E20C5F893E6DC5FBF2E61FB4C54DFF69E7CF_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_ValueFromByteArray_TisSingle_tE07797BA3C98D4CA9B5A19413C19A76688AB899E_mA63BCB726472D5DDB910066AC162C379EDC64645_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_ValueFromByteArray_TisString_t_m0AA6001643C0B3FAAE1B4558B9B77CD82411E198_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_tE07797BA3C98D4CA9B5A19413C19A76688AB899E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * V_1 = NULL;
	CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34* V_2 = NULL;
	Il2CppChar V_3 = 0x0;
	RuntimeObject * V_4 = NULL;
	CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34* V_5 = NULL;
	int32_t V_6 = 0;
	Il2CppChar V_7 = 0x0;
	{
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_0 = ___data1;
		int32_t* L_1 = ___start2;
		IL2CPP_RUNTIME_CLASS_INIT(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		String_t* L_2;
		L_2 = OscPacket_ValueFromByteArray_TisString_t_m0AA6001643C0B3FAAE1B4558B9B77CD82411E198(L_0, (int32_t*)L_1, /*hidden argument*/OscPacket_ValueFromByteArray_TisString_t_m0AA6001643C0B3FAAE1B4558B9B77CD82411E198_RuntimeMethod_var);
		V_0 = L_2;
		IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * L_3 = ___sourceEndPoint0;
		String_t* L_4 = V_0;
		OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * L_5 = (OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 *)il2cpp_codegen_object_new(OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2_il2cpp_TypeInfo_var);
		OscMessage__ctor_mA1D568F6D49C1FCD89670DF76F9B00E157965A81(L_5, L_3, L_4, (OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591 *)NULL, /*hidden argument*/NULL);
		V_1 = L_5;
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_6 = ___data1;
		int32_t* L_7 = ___start2;
		String_t* L_8;
		L_8 = OscPacket_ValueFromByteArray_TisString_t_m0AA6001643C0B3FAAE1B4558B9B77CD82411E198(L_6, (int32_t*)L_7, /*hidden argument*/OscPacket_ValueFromByteArray_TisString_t_m0AA6001643C0B3FAAE1B4558B9B77CD82411E198_RuntimeMethod_var);
		NullCheck(L_8);
		CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34* L_9;
		L_9 = String_ToCharArray_m33E93AEB7086CBEBDFA5730EAAC49686F144089C(L_8, /*hidden argument*/NULL);
		V_2 = L_9;
		CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34* L_10 = V_2;
		V_5 = L_10;
		V_6 = 0;
		goto IL_017e;
	}

IL_0029:
	{
		CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34* L_11 = V_5;
		int32_t L_12 = V_6;
		NullCheck(L_11);
		int32_t L_13 = L_12;
		uint16_t L_14 = (uint16_t)(L_11)->GetAt(static_cast<il2cpp_array_size_t>(L_13));
		V_3 = L_14;
		Il2CppChar L_15 = V_3;
		V_7 = L_15;
		Il2CppChar L_16 = V_7;
		if ((((int32_t)L_16) > ((int32_t)((int32_t)73))))
		{
			goto IL_0058;
		}
	}
	{
		Il2CppChar L_17 = V_7;
		if ((((int32_t)L_17) == ((int32_t)((int32_t)44))))
		{
			goto IL_0178;
		}
	}
	{
		Il2CppChar L_18 = V_7;
		if ((((int32_t)L_18) == ((int32_t)((int32_t)70))))
		{
			goto IL_0154;
		}
	}
	{
		Il2CppChar L_19 = V_7;
		if ((((int32_t)L_19) == ((int32_t)((int32_t)73))))
		{
			goto IL_0163;
		}
	}
	{
		goto IL_0178;
	}

IL_0058:
	{
		Il2CppChar L_20 = V_7;
		if ((((int32_t)L_20) > ((int32_t)((int32_t)84))))
		{
			goto IL_007e;
		}
	}
	{
		Il2CppChar L_21 = V_7;
		if ((((int32_t)L_21) == ((int32_t)((int32_t)78))))
		{
			goto IL_015e;
		}
	}
	{
		Il2CppChar L_22 = V_7;
		switch (((int32_t)il2cpp_codegen_subtract((int32_t)L_22, (int32_t)((int32_t)83))))
		{
			case 0:
			{
				goto IL_0109;
			}
			case 1:
			{
				goto IL_014a;
			}
		}
	}
	{
		goto IL_0178;
	}

IL_007e:
	{
		Il2CppChar L_23 = V_7;
		switch (((int32_t)il2cpp_codegen_subtract((int32_t)L_23, (int32_t)((int32_t)98))))
		{
			case 0:
			{
				goto IL_0114;
			}
			case 1:
			{
				goto IL_012a;
			}
			case 2:
			{
				goto IL_00f9;
			}
			case 3:
			{
				goto IL_0178;
			}
			case 4:
			{
				goto IL_00e9;
			}
			case 5:
			{
				goto IL_0178;
			}
			case 6:
			{
				goto IL_00d6;
			}
			case 7:
			{
				goto IL_00c3;
			}
		}
	}
	{
		Il2CppChar L_24 = V_7;
		switch (((int32_t)il2cpp_codegen_subtract((int32_t)L_24, (int32_t)((int32_t)114))))
		{
			case 0:
			{
				goto IL_013a;
			}
			case 1:
			{
				goto IL_0109;
			}
			case 2:
			{
				goto IL_011f;
			}
		}
	}
	{
		goto IL_0178;
	}

IL_00c3:
	{
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_25 = ___data1;
		int32_t* L_26 = ___start2;
		IL2CPP_RUNTIME_CLASS_INIT(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		int32_t L_27;
		L_27 = OscPacket_ValueFromByteArray_TisInt32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046_m32A19AD88A6771691E46A055613812D325C93D8A(L_25, (int32_t*)L_26, /*hidden argument*/OscPacket_ValueFromByteArray_TisInt32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046_m32A19AD88A6771691E46A055613812D325C93D8A_RuntimeMethod_var);
		int32_t L_28 = L_27;
		RuntimeObject * L_29 = Box(Int32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046_il2cpp_TypeInfo_var, &L_28);
		V_4 = L_29;
		goto IL_016f;
	}

IL_00d6:
	{
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_30 = ___data1;
		int32_t* L_31 = ___start2;
		IL2CPP_RUNTIME_CLASS_INIT(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		int64_t L_32;
		L_32 = OscPacket_ValueFromByteArray_TisInt64_t378EE0D608BD3107E77238E85F30D2BBD46981F3_mC08348CB553E77F8AB350FEFA1FF2E8FFD6C9BFA(L_30, (int32_t*)L_31, /*hidden argument*/OscPacket_ValueFromByteArray_TisInt64_t378EE0D608BD3107E77238E85F30D2BBD46981F3_mC08348CB553E77F8AB350FEFA1FF2E8FFD6C9BFA_RuntimeMethod_var);
		int64_t L_33 = L_32;
		RuntimeObject * L_34 = Box(Int64_t378EE0D608BD3107E77238E85F30D2BBD46981F3_il2cpp_TypeInfo_var, &L_33);
		V_4 = L_34;
		goto IL_016f;
	}

IL_00e9:
	{
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_35 = ___data1;
		int32_t* L_36 = ___start2;
		IL2CPP_RUNTIME_CLASS_INIT(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		float L_37;
		L_37 = OscPacket_ValueFromByteArray_TisSingle_tE07797BA3C98D4CA9B5A19413C19A76688AB899E_mA63BCB726472D5DDB910066AC162C379EDC64645(L_35, (int32_t*)L_36, /*hidden argument*/OscPacket_ValueFromByteArray_TisSingle_tE07797BA3C98D4CA9B5A19413C19A76688AB899E_mA63BCB726472D5DDB910066AC162C379EDC64645_RuntimeMethod_var);
		float L_38 = L_37;
		RuntimeObject * L_39 = Box(Single_tE07797BA3C98D4CA9B5A19413C19A76688AB899E_il2cpp_TypeInfo_var, &L_38);
		V_4 = L_39;
		goto IL_016f;
	}

IL_00f9:
	{
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_40 = ___data1;
		int32_t* L_41 = ___start2;
		IL2CPP_RUNTIME_CLASS_INIT(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		double L_42;
		L_42 = OscPacket_ValueFromByteArray_TisDouble_t42821932CB52DE2057E685D0E1AF3DE5033D2181_mCF0D171BA5AD93AF48B22E2341F024AD314EC82B(L_40, (int32_t*)L_41, /*hidden argument*/OscPacket_ValueFromByteArray_TisDouble_t42821932CB52DE2057E685D0E1AF3DE5033D2181_mCF0D171BA5AD93AF48B22E2341F024AD314EC82B_RuntimeMethod_var);
		double L_43 = L_42;
		RuntimeObject * L_44 = Box(Double_t42821932CB52DE2057E685D0E1AF3DE5033D2181_il2cpp_TypeInfo_var, &L_43);
		V_4 = L_44;
		goto IL_016f;
	}

IL_0109:
	{
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_45 = ___data1;
		int32_t* L_46 = ___start2;
		IL2CPP_RUNTIME_CLASS_INIT(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		String_t* L_47;
		L_47 = OscPacket_ValueFromByteArray_TisString_t_m0AA6001643C0B3FAAE1B4558B9B77CD82411E198(L_45, (int32_t*)L_46, /*hidden argument*/OscPacket_ValueFromByteArray_TisString_t_m0AA6001643C0B3FAAE1B4558B9B77CD82411E198_RuntimeMethod_var);
		V_4 = L_47;
		goto IL_016f;
	}

IL_0114:
	{
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_48 = ___data1;
		int32_t* L_49 = ___start2;
		IL2CPP_RUNTIME_CLASS_INIT(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_50;
		L_50 = OscPacket_ValueFromByteArray_TisByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726_m1A34F855D9CC53697284E7EFDBBCD4BC64E3E8EE(L_48, (int32_t*)L_49, /*hidden argument*/OscPacket_ValueFromByteArray_TisByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726_m1A34F855D9CC53697284E7EFDBBCD4BC64E3E8EE_RuntimeMethod_var);
		V_4 = (RuntimeObject *)L_50;
		goto IL_016f;
	}

IL_011f:
	{
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_51 = ___data1;
		int32_t* L_52 = ___start2;
		IL2CPP_RUNTIME_CLASS_INIT(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * L_53;
		L_53 = OscPacket_ValueFromByteArray_TisOscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_mE6B1E20C5F893E6DC5FBF2E61FB4C54DFF69E7CF(L_51, (int32_t*)L_52, /*hidden argument*/OscPacket_ValueFromByteArray_TisOscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_mE6B1E20C5F893E6DC5FBF2E61FB4C54DFF69E7CF_RuntimeMethod_var);
		V_4 = L_53;
		goto IL_016f;
	}

IL_012a:
	{
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_54 = ___data1;
		int32_t* L_55 = ___start2;
		IL2CPP_RUNTIME_CLASS_INIT(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		Il2CppChar L_56;
		L_56 = OscPacket_ValueFromByteArray_TisChar_tFF60D8E7E89A20BE2294A003734341BD1DF43E14_m4A612DEE0C33EEDBF5AEB0708E5E61CDA9D45F62(L_54, (int32_t*)L_55, /*hidden argument*/OscPacket_ValueFromByteArray_TisChar_tFF60D8E7E89A20BE2294A003734341BD1DF43E14_m4A612DEE0C33EEDBF5AEB0708E5E61CDA9D45F62_RuntimeMethod_var);
		Il2CppChar L_57 = L_56;
		RuntimeObject * L_58 = Box(Char_tFF60D8E7E89A20BE2294A003734341BD1DF43E14_il2cpp_TypeInfo_var, &L_57);
		V_4 = L_58;
		goto IL_016f;
	}

IL_013a:
	{
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_59 = ___data1;
		int32_t* L_60 = ___start2;
		IL2CPP_RUNTIME_CLASS_INIT(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		Color_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334  L_61;
		L_61 = OscPacket_ValueFromByteArray_TisColor_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334_m2D0F95410365A923A816432EF1F027047CE65238(L_59, (int32_t*)L_60, /*hidden argument*/OscPacket_ValueFromByteArray_TisColor_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334_m2D0F95410365A923A816432EF1F027047CE65238_RuntimeMethod_var);
		Color_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334  L_62 = L_61;
		RuntimeObject * L_63 = Box(Color_tB0FBEA12AA14B2F51EE7614D4EBB392F7EF04334_il2cpp_TypeInfo_var, &L_62);
		V_4 = L_63;
		goto IL_016f;
	}

IL_014a:
	{
		bool L_64 = ((bool)1);
		RuntimeObject * L_65 = Box(Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_il2cpp_TypeInfo_var, &L_64);
		V_4 = L_65;
		goto IL_016f;
	}

IL_0154:
	{
		bool L_66 = ((bool)0);
		RuntimeObject * L_67 = Box(Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_il2cpp_TypeInfo_var, &L_66);
		V_4 = L_67;
		goto IL_016f;
	}

IL_015e:
	{
		V_4 = NULL;
		goto IL_016f;
	}

IL_0163:
	{
		float L_68 = (std::numeric_limits<float>::infinity());
		RuntimeObject * L_69 = Box(Single_tE07797BA3C98D4CA9B5A19413C19A76688AB899E_il2cpp_TypeInfo_var, &L_68);
		V_4 = L_69;
	}

IL_016f:
	{
		OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * L_70 = V_1;
		RuntimeObject * L_71 = V_4;
		NullCheck(L_70);
		int32_t L_72;
		L_72 = GenericVirtFuncInvoker1< int32_t, RuntimeObject * >::Invoke(OscPacket_Append_TisRuntimeObject_mC8350C70C82033B5A4E83A2F005E6D173918DEA6_RuntimeMethod_var, L_70, L_71);
	}

IL_0178:
	{
		int32_t L_73 = V_6;
		V_6 = ((int32_t)il2cpp_codegen_add((int32_t)L_73, (int32_t)1));
	}

IL_017e:
	{
		int32_t L_74 = V_6;
		CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34* L_75 = V_5;
		NullCheck(L_75);
		if ((((int32_t)L_74) < ((int32_t)((int32_t)((int32_t)(((RuntimeArray*)L_75)->max_length))))))
		{
			goto IL_0029;
		}
	}
	{
		OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * L_76 = V_1;
		return L_76;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Bespoke.Common.Osc.OscMessage Bespoke.Common.Osc.OscMessageReceivedEventArgs::get_Message()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * OscMessageReceivedEventArgs_get_Message_mE71554F4B20C0975090B1498AE0781680F0783F6 (OscMessageReceivedEventArgs_t8E8CE6EC7E84AF0892F400AB363313C22B8C4E83 * __this, const RuntimeMethod* method)
{
	{
		OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * L_0 = __this->get_mMessage_1();
		return L_0;
	}
}
// System.Void Bespoke.Common.Osc.OscMessageReceivedEventArgs::.ctor(Bespoke.Common.Osc.OscMessage)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscMessageReceivedEventArgs__ctor_mFDDFFCCE818650EE040AB7BF15C2D2B24945C84B (OscMessageReceivedEventArgs_t8E8CE6EC7E84AF0892F400AB363313C22B8C4E83 * __this, OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * ___message0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA_il2cpp_TypeInfo_var);
		EventArgs__ctor_m5ECB9A8ED0A9E2DBB1ED999BAC1CB44F4354E571(__this, /*hidden argument*/NULL);
		OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * L_0 = ___message0;
		Assert_ParamIsNotNull_mD80AE1B0A6FE56720DF0480A18BE9C4A7CEBEE70(L_0, /*hidden argument*/NULL);
		OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * L_1 = ___message0;
		__this->set_mMessage_1(L_1);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Boolean Bespoke.Common.Osc.OscPacket::get_LittleEndianByteOrder()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool OscPacket_get_LittleEndianByteOrder_mAD90FE000F92E9C98C43812B33653B589A84AAF1 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		bool L_0 = ((OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_StaticFields*)il2cpp_codegen_static_fields_for(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var))->get_sLittleEndianByteOrder_0();
		return L_0;
	}
}
// System.String Bespoke.Common.Osc.OscPacket::get_Address()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* OscPacket_get_Address_mD45518659033C523F1F8B38447C0FA5F52B3C1B5 (OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * __this, const RuntimeMethod* method)
{
	{
		String_t* L_0 = __this->get_mAddress_2();
		return L_0;
	}
}
// System.Collections.Generic.IList`1<System.Object> Bespoke.Common.Osc.OscPacket::get_Data()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* OscPacket_get_Data_mD670EFFAF7A2F1D60A157BB958512515DAAF92FA (OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_AsReadOnly_m2A562BCF70602A773C266FE3B151E1A56D884F71_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * L_0 = __this->get_mData_3();
		NullCheck(L_0);
		ReadOnlyCollection_1_t921D1901AD35062BE31FAEB0798A4B814F33A3C3 * L_1;
		L_1 = List_1_AsReadOnly_m2A562BCF70602A773C266FE3B151E1A56D884F71(L_0, /*hidden argument*/List_1_AsReadOnly_m2A562BCF70602A773C266FE3B151E1A56D884F71_RuntimeMethod_var);
		return L_1;
	}
}
// System.Void Bespoke.Common.Osc.OscPacket::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscPacket__cctor_mF946815C9D17EBF5C09FAF8040A212D919FBAA49 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		((OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_StaticFields*)il2cpp_codegen_static_fields_for(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var))->set_sLittleEndianByteOrder_0((bool)0);
		UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920 * L_0 = (UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920 *)il2cpp_codegen_object_new(UdpClient_tB1B7578C96A20B6A0B58AC3FD3E1CB469375B920_il2cpp_TypeInfo_var);
		UdpClient__ctor_m2042D1CBDA4D588704EF4828D65C46935B77C778(L_0, /*hidden argument*/NULL);
		((OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_StaticFields*)il2cpp_codegen_static_fields_for(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var))->set_sUdpClient_5(L_0);
		return;
	}
}
// System.Void Bespoke.Common.Osc.OscPacket::.ctor(System.Net.IPEndPoint,System.String,Bespoke.Common.Osc.OscClient)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscPacket__ctor_m1BD07E88061C178FBB726E239FDE56DA032317D8 (OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * __this, IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___sourceEndPoint0, String_t* ___address1, OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591 * ___client2, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_m0F0E00088CF56FEACC9E32D8B7D91B93D91DAA3B_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Object__ctor_m88880E0413421D13FD95325EDCE231707CE1F405(__this, /*hidden argument*/NULL);
		String_t* L_0 = ___address1;
		bool L_1;
		L_1 = String_IsNullOrEmpty_m9AFBB5335B441B94E884B8A9D4A27AD60E3D7F7C(L_0, /*hidden argument*/NULL);
		Assert_IsFalse_mED3CB0B89BCBEB83A4F45840D3CCB20604B7FA80(L_1, /*hidden argument*/NULL);
		IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * L_2 = ___sourceEndPoint0;
		__this->set_mSourceEndPoint_1(L_2);
		String_t* L_3 = ___address1;
		__this->set_mAddress_2(L_3);
		List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 * L_4 = (List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5 *)il2cpp_codegen_object_new(List_1_t3F94120C77410A62EAE48421CF166B83AB95A2F5_il2cpp_TypeInfo_var);
		List_1__ctor_m0F0E00088CF56FEACC9E32D8B7D91B93D91DAA3B(L_4, /*hidden argument*/List_1__ctor_m0F0E00088CF56FEACC9E32D8B7D91B93D91DAA3B_RuntimeMethod_var);
		__this->set_mData_3(L_4);
		OscClient_t22213EE006DC2814942EBC923B4D38B5C510A591 * L_5 = ___client2;
		__this->set_mClient_4(L_5);
		return;
	}
}
// Bespoke.Common.Osc.OscPacket Bespoke.Common.Osc.OscPacket::FromByteArray(System.Net.IPEndPoint,System.Byte[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * OscPacket_FromByteArray_mF4ADF635CE40A8B3A3D1BFD76C69292817E94320 (IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___sourceEndPoint0, ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_0 = ___data1;
		Assert_ParamIsNotNull_mD80AE1B0A6FE56720DF0480A18BE9C4A7CEBEE70((RuntimeObject *)(RuntimeObject *)L_0, /*hidden argument*/NULL);
		V_0 = 0;
		IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * L_1 = ___sourceEndPoint0;
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_2 = ___data1;
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_3 = ___data1;
		NullCheck(L_3);
		IL2CPP_RUNTIME_CLASS_INIT(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * L_4;
		L_4 = OscPacket_FromByteArray_m5366863927BC90527E6510B1118F2D0DF9F31D03(L_1, L_2, (int32_t*)(&V_0), ((int32_t)((int32_t)(((RuntimeArray*)L_3)->max_length))), /*hidden argument*/NULL);
		return L_4;
	}
}
// Bespoke.Common.Osc.OscPacket Bespoke.Common.Osc.OscPacket::FromByteArray(System.Net.IPEndPoint,System.Byte[],System.Int32&,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * OscPacket_FromByteArray_m5366863927BC90527E6510B1118F2D0DF9F31D03 (IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___sourceEndPoint0, ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data1, int32_t* ___start2, int32_t ___end3, const RuntimeMethod* method)
{
	{
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_0 = ___data1;
		int32_t* L_1 = ___start2;
		int32_t L_2 = *((int32_t*)L_1);
		NullCheck(L_0);
		int32_t L_3 = L_2;
		uint8_t L_4 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_3));
		if ((!(((uint32_t)L_4) == ((uint32_t)((int32_t)35)))))
		{
			goto IL_0012;
		}
	}
	{
		IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * L_5 = ___sourceEndPoint0;
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_6 = ___data1;
		int32_t* L_7 = ___start2;
		int32_t L_8 = ___end3;
		OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * L_9;
		L_9 = OscBundle_FromByteArray_m694F901543F84AA8BA5A0BCD90A777EC57A59E6B(L_5, L_6, (int32_t*)L_7, L_8, /*hidden argument*/NULL);
		return L_9;
	}

IL_0012:
	{
		IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * L_10 = ___sourceEndPoint0;
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_11 = ___data1;
		int32_t* L_12 = ___start2;
		OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * L_13;
		L_13 = OscMessage_FromByteArray_m57593CA31720C3B5F75D6D8EAC40E9F284AA2001(L_10, L_11, (int32_t*)L_12, /*hidden argument*/NULL);
		return L_13;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Bespoke.Common.Osc.OscPacketReceivedEventArgs::.ctor(Bespoke.Common.Osc.OscPacket)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscPacketReceivedEventArgs__ctor_mCBE38234059260263BE854F6BC0528E4456189FF (OscPacketReceivedEventArgs_t61CB29F943015645037B535D6348EA15E19C680B * __this, OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * ___packet0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(EventArgs_tBCAACA538A5195B6D6C8DFCC3524A2A4A67FD8BA_il2cpp_TypeInfo_var);
		EventArgs__ctor_m5ECB9A8ED0A9E2DBB1ED999BAC1CB44F4354E571(__this, /*hidden argument*/NULL);
		OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * L_0 = ___packet0;
		Assert_ParamIsNotNull_mD80AE1B0A6FE56720DF0480A18BE9C4A7CEBEE70(L_0, /*hidden argument*/NULL);
		OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * L_1 = ___packet0;
		__this->set_mPacket_1(L_1);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Bespoke.Common.Osc.OscServer::add_MessageReceived(System.EventHandler`1<Bespoke.Common.Osc.OscMessageReceivedEventArgs>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer_add_MessageReceived_mAE139D804F3FF5DB41E97E1F69BDBE5A9EDBA6BD (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * V_0 = NULL;
	EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * V_1 = NULL;
	EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * V_2 = NULL;
	{
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * L_0 = __this->get_MessageReceived_2();
		V_0 = L_0;
	}

IL_0007:
	{
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * L_1 = V_0;
		V_1 = L_1;
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * L_2 = V_1;
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 *)CastclassSealed((RuntimeObject*)L_4, EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714_il2cpp_TypeInfo_var));
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 ** L_5 = __this->get_address_of_MessageReceived_2();
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * L_6 = V_2;
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * L_7 = V_1;
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * L_8;
		L_8 = InterlockedCompareExchangeImpl<EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 *>((EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 **)L_5, L_6, L_7);
		V_0 = L_8;
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * L_9 = V_0;
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * L_10 = V_1;
		if ((!(((RuntimeObject*)(EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 *)L_9) == ((RuntimeObject*)(EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Bespoke.Common.Osc.OscServer::remove_MessageReceived(System.EventHandler`1<Bespoke.Common.Osc.OscMessageReceivedEventArgs>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer_remove_MessageReceived_m5FE3775F3034089A0C5C330C4FDE18FE55431D3B (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * V_0 = NULL;
	EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * V_1 = NULL;
	EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * V_2 = NULL;
	{
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * L_0 = __this->get_MessageReceived_2();
		V_0 = L_0;
	}

IL_0007:
	{
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * L_1 = V_0;
		V_1 = L_1;
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * L_2 = V_1;
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 *)CastclassSealed((RuntimeObject*)L_4, EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714_il2cpp_TypeInfo_var));
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 ** L_5 = __this->get_address_of_MessageReceived_2();
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * L_6 = V_2;
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * L_7 = V_1;
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * L_8;
		L_8 = InterlockedCompareExchangeImpl<EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 *>((EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 **)L_5, L_6, L_7);
		V_0 = L_8;
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * L_9 = V_0;
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * L_10 = V_1;
		if ((!(((RuntimeObject*)(EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 *)L_9) == ((RuntimeObject*)(EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Bespoke.Common.Osc.OscServer::add_ReceiveErrored(System.EventHandler`1<Bespoke.Common.ExceptionEventArgs>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer_add_ReceiveErrored_mE3F852ECF88BCA5EA84BC2A4C672398D90A81566 (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * V_0 = NULL;
	EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * V_1 = NULL;
	EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * V_2 = NULL;
	{
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * L_0 = __this->get_ReceiveErrored_3();
		V_0 = L_0;
	}

IL_0007:
	{
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * L_1 = V_0;
		V_1 = L_1;
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * L_2 = V_1;
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Combine_m631D10D6CFF81AB4F237B9D549B235A54F45FA55(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F *)CastclassSealed((RuntimeObject*)L_4, EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F_il2cpp_TypeInfo_var));
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F ** L_5 = __this->get_address_of_ReceiveErrored_3();
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * L_6 = V_2;
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * L_7 = V_1;
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * L_8;
		L_8 = InterlockedCompareExchangeImpl<EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F *>((EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F **)L_5, L_6, L_7);
		V_0 = L_8;
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * L_9 = V_0;
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * L_10 = V_1;
		if ((!(((RuntimeObject*)(EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F *)L_9) == ((RuntimeObject*)(EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Bespoke.Common.Osc.OscServer::remove_ReceiveErrored(System.EventHandler`1<Bespoke.Common.ExceptionEventArgs>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer_remove_ReceiveErrored_m320939973375C2BA55CEFE70C4554AED1F684573 (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * V_0 = NULL;
	EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * V_1 = NULL;
	EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * V_2 = NULL;
	{
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * L_0 = __this->get_ReceiveErrored_3();
		V_0 = L_0;
	}

IL_0007:
	{
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * L_1 = V_0;
		V_1 = L_1;
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * L_2 = V_1;
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * L_3 = ___value0;
		Delegate_t * L_4;
		L_4 = Delegate_Remove_m8B4AD17254118B2904720D55C9B34FB3DCCBD7D4(L_2, L_3, /*hidden argument*/NULL);
		V_2 = ((EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F *)CastclassSealed((RuntimeObject*)L_4, EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F_il2cpp_TypeInfo_var));
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F ** L_5 = __this->get_address_of_ReceiveErrored_3();
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * L_6 = V_2;
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * L_7 = V_1;
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * L_8;
		L_8 = InterlockedCompareExchangeImpl<EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F *>((EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F **)L_5, L_6, L_7);
		V_0 = L_8;
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * L_9 = V_0;
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * L_10 = V_1;
		if ((!(((RuntimeObject*)(EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F *)L_9) == ((RuntimeObject*)(EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F *)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void Bespoke.Common.Osc.OscServer::set_FilterRegisteredMethods(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer_set_FilterRegisteredMethods_m5256A4D6AE1A44DADA814BE10A20AC5D66FB7E99 (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, bool ___value0, const RuntimeMethod* method)
{
	{
		bool L_0 = ___value0;
		__this->set_mFilterRegisteredMethods_13(L_0);
		return;
	}
}
// System.Void Bespoke.Common.Osc.OscServer::set_ConsumeParsingExceptions(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer_set_ConsumeParsingExceptions_m9E00932796D7C907815D91392ED59446539D8A89 (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, bool ___value0, const RuntimeMethod* method)
{
	{
		bool L_0 = ___value0;
		__this->set_mConsumeParsingExceptions_16(L_0);
		return;
	}
}
// System.Void Bespoke.Common.Osc.OscServer::.ctor(System.Net.TransportType,System.Net.IPAddress,System.Int32,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer__ctor_mC550C46705A58B8C709A5EEF4E02044EF7D80A78 (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, int32_t ___transportType0, IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___ipAddress1, int32_t ___port2, bool ___consumeParsingExceptions3, const RuntimeMethod* method)
{
	{
		int32_t L_0 = ___transportType0;
		IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * L_1 = ___ipAddress1;
		int32_t L_2 = ___port2;
		bool L_3 = ___consumeParsingExceptions3;
		OscServer__ctor_m498CAB23F18494FEADE8230BBF2977488AA38834(__this, L_0, L_1, L_2, (IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE *)NULL, 0, L_3, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Bespoke.Common.Osc.OscServer::.ctor(System.Net.TransportType,System.Net.IPAddress,System.Int32,System.Net.IPAddress,Bespoke.Common.Net.TransmissionType,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer__ctor_m498CAB23F18494FEADE8230BBF2977488AA38834 (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, int32_t ___transportType0, IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___ipAddress1, int32_t ___port2, IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * ___multicastAddress3, int32_t ___transmissionType4, bool ___consumeParsingExceptions5, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EventHandler_1__ctor_m8D618A691D600BE62ECACECD277A03C3EFD5B474_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EventHandler_1__ctor_mA440F83BE7D36CF2D080BA620518CCD0B2114A06_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EventHandler_1_tEFAA9D3F682231A3C61310E1CE32DB931BBBAE43_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EventHandler_1_tEFE51D141A816E328C23211083B6A5CDCAAF1BED_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_m30C52A4F2828D86CA3FAB0B1B583948F4DA9F1F9_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscServer_mTcpServer_DataReceived_mF3226741BBCC4C27878F698FA408C98E5A970DC2_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscServer_mUdpServer_DataReceived_mA52B3AF0ABC91329EF251A4092268301E472E57B_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t G_B3_0 = 0;
	{
		IPServer__ctor_m83867CDF01D9898FC860351B370DE02B305E568D(__this, /*hidden argument*/NULL);
		int32_t L_0 = ___transportType0;
		if ((((int32_t)L_0) == ((int32_t)1)))
		{
			goto IL_0010;
		}
	}
	{
		int32_t L_1 = ___transportType0;
		G_B3_0 = ((((int32_t)L_1) == ((int32_t)2))? 1 : 0);
		goto IL_0011;
	}

IL_0010:
	{
		G_B3_0 = 1;
	}

IL_0011:
	{
		Assert_IsTrue_m1ABA281F642FE8A1C9F08DC02CA7B757B5D0C2AE((bool)G_B3_0, /*hidden argument*/NULL);
		int32_t L_2 = ___transportType0;
		if ((!(((uint32_t)L_2) == ((uint32_t)2))))
		{
			goto IL_0029;
		}
	}
	{
		int32_t L_3 = ___transmissionType4;
		if (!L_3)
		{
			goto IL_0029;
		}
	}
	{
		InvalidOperationException_t10D3EE59AD28EC641ACEE05BCA4271A527E5ECAB * L_4 = (InvalidOperationException_t10D3EE59AD28EC641ACEE05BCA4271A527E5ECAB *)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t10D3EE59AD28EC641ACEE05BCA4271A527E5ECAB_il2cpp_TypeInfo_var)));
		InvalidOperationException__ctor_mC012CE552988309733C896F3FEA8249171E4402E(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralB952A8DB3269CA1A3FB83A3B517860948B30AF01)), /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&OscServer__ctor_m498CAB23F18494FEADE8230BBF2977488AA38834_RuntimeMethod_var)));
	}

IL_0029:
	{
		int32_t L_5 = ___transportType0;
		__this->set_mTransportType_4(L_5);
		IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * L_6 = ___ipAddress1;
		__this->set_mIPAddress_5(L_6);
		int32_t L_7 = ___port2;
		__this->set_mPort_6(L_7);
		IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * L_8 = ___ipAddress1;
		int32_t L_9 = ___port2;
		IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * L_10 = (IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E *)il2cpp_codegen_object_new(IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E_il2cpp_TypeInfo_var);
		IPEndPoint__ctor_m22783A215BA0B38674F6A6CB6803804268561321(L_10, L_8, L_9, /*hidden argument*/NULL);
		__this->set_mIPEndPoint_7(L_10);
		int32_t L_11 = ___transmissionType4;
		__this->set_mTransmissionType_14(L_11);
		int32_t L_12 = __this->get_mTransmissionType_14();
		if ((!(((uint32_t)L_12) == ((uint32_t)1))))
		{
			goto IL_006b;
		}
	}
	{
		IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * L_13 = ___multicastAddress3;
		Assert_ParamIsNotNull_mD80AE1B0A6FE56720DF0480A18BE9C4A7CEBEE70(L_13, /*hidden argument*/NULL);
		IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * L_14 = ___multicastAddress3;
		__this->set_mMulticastAddress_8(L_14);
	}

IL_006b:
	{
		List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 * L_15 = (List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 *)il2cpp_codegen_object_new(List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3_il2cpp_TypeInfo_var);
		List_1__ctor_m30C52A4F2828D86CA3FAB0B1B583948F4DA9F1F9(L_15, /*hidden argument*/List_1__ctor_m30C52A4F2828D86CA3FAB0B1B583948F4DA9F1F9_RuntimeMethod_var);
		__this->set_mRegisteredMethods_12(L_15);
		__this->set_mFilterRegisteredMethods_13((bool)1);
		bool L_16 = ___consumeParsingExceptions5;
		__this->set_mConsumeParsingExceptions_16(L_16);
		int32_t L_17 = __this->get_mTransportType_4();
		V_0 = L_17;
		int32_t L_18 = V_0;
		switch (((int32_t)il2cpp_codegen_subtract((int32_t)L_18, (int32_t)1)))
		{
			case 0:
			{
				goto IL_009e;
			}
			case 1:
			{
				goto IL_00d9;
			}
		}
	}
	{
		goto IL_010e;
	}

IL_009e:
	{
		IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * L_19 = __this->get_mIPAddress_5();
		int32_t L_20 = __this->get_mPort_6();
		IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * L_21 = __this->get_mMulticastAddress_8();
		int32_t L_22 = __this->get_mTransmissionType_14();
		UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2 * L_23 = (UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2 *)il2cpp_codegen_object_new(UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2_il2cpp_TypeInfo_var);
		UdpServer__ctor_mE6D094924DBA73D6CBD181FA0EB6C359B448EB4F(L_23, L_19, L_20, L_21, L_22, /*hidden argument*/NULL);
		__this->set_mUdpServer_9(L_23);
		UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2 * L_24 = __this->get_mUdpServer_9();
		EventHandler_1_tEFE51D141A816E328C23211083B6A5CDCAAF1BED * L_25 = (EventHandler_1_tEFE51D141A816E328C23211083B6A5CDCAAF1BED *)il2cpp_codegen_object_new(EventHandler_1_tEFE51D141A816E328C23211083B6A5CDCAAF1BED_il2cpp_TypeInfo_var);
		EventHandler_1__ctor_mA440F83BE7D36CF2D080BA620518CCD0B2114A06(L_25, __this, (intptr_t)((intptr_t)OscServer_mUdpServer_DataReceived_mA52B3AF0ABC91329EF251A4092268301E472E57B_RuntimeMethod_var), /*hidden argument*/EventHandler_1__ctor_mA440F83BE7D36CF2D080BA620518CCD0B2114A06_RuntimeMethod_var);
		NullCheck(L_24);
		UdpServer_add_DataReceived_mE26DF9A65DE21AAE8FC91E6B79AB13876F9C454C(L_24, L_25, /*hidden argument*/NULL);
		return;
	}

IL_00d9:
	{
		IPAddress_t2B5F1762B4B9935BA6CA8FB12C87282C72E035AE * L_26 = __this->get_mIPAddress_5();
		int32_t L_27 = __this->get_mPort_6();
		IL2CPP_RUNTIME_CLASS_INIT(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		bool L_28;
		L_28 = OscPacket_get_LittleEndianByteOrder_mAD90FE000F92E9C98C43812B33653B589A84AAF1_inline(/*hidden argument*/NULL);
		TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17 * L_29 = (TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17 *)il2cpp_codegen_object_new(TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17_il2cpp_TypeInfo_var);
		TcpServer__ctor_m3F2C5B188F93E9A4815993D95FFAFE5F4FE867A9(L_29, L_26, L_27, (bool)1, L_28, /*hidden argument*/NULL);
		__this->set_mTcpServer_10(L_29);
		TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17 * L_30 = __this->get_mTcpServer_10();
		EventHandler_1_tEFAA9D3F682231A3C61310E1CE32DB931BBBAE43 * L_31 = (EventHandler_1_tEFAA9D3F682231A3C61310E1CE32DB931BBBAE43 *)il2cpp_codegen_object_new(EventHandler_1_tEFAA9D3F682231A3C61310E1CE32DB931BBBAE43_il2cpp_TypeInfo_var);
		EventHandler_1__ctor_m8D618A691D600BE62ECACECD277A03C3EFD5B474(L_31, __this, (intptr_t)((intptr_t)OscServer_mTcpServer_DataReceived_mF3226741BBCC4C27878F698FA408C98E5A970DC2_RuntimeMethod_var), /*hidden argument*/EventHandler_1__ctor_m8D618A691D600BE62ECACECD277A03C3EFD5B474_RuntimeMethod_var);
		NullCheck(L_30);
		TcpServer_add_DataReceived_mEDB155A72C3220CF70350DAAF9ACF197272B5079(L_30, L_31, /*hidden argument*/NULL);
		return;
	}

IL_010e:
	{
		int32_t L_32 = __this->get_mTransportType_4();
		int32_t L_33 = L_32;
		RuntimeObject * L_34 = Box(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&TransportType_t19FD2303B5B680C76D1B24D778D0959E9AE8198C_il2cpp_TypeInfo_var)), &L_33);
		NullCheck(L_34);
		String_t* L_35;
		L_35 = VirtFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_34);
		String_t* L_36;
		L_36 = String_Concat_m4B4AB72618348C5DFBFBA8DED84B9E2EBDB55E1B(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral6CB20796A7CD300175C3C97D9D0B31A65326CA4E)), L_35, /*hidden argument*/NULL);
		InvalidOperationException_t10D3EE59AD28EC641ACEE05BCA4271A527E5ECAB * L_37 = (InvalidOperationException_t10D3EE59AD28EC641ACEE05BCA4271A527E5ECAB *)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t10D3EE59AD28EC641ACEE05BCA4271A527E5ECAB_il2cpp_TypeInfo_var)));
		InvalidOperationException__ctor_mC012CE552988309733C896F3FEA8249171E4402E(L_37, L_36, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_37, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&OscServer__ctor_m498CAB23F18494FEADE8230BBF2977488AA38834_RuntimeMethod_var)));
	}
}
// System.Void Bespoke.Common.Osc.OscServer::Start()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer_Start_m1044E6A9E06A238BF97E02C480569E848250789E (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TcpServer_Start_mD4EF9EFDD7F305349C3C8B52B63CE46A45920A36_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ThreadStart_tA13019555BA3CB2B0128F0880760196BF790E687_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral59D2C03D11B34581CD247E011280983E6284ED2D);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		il2cpp_codegen_memory_barrier();
		__this->set_mHandleMessages_15(1);
		int32_t L_0 = __this->get_mTransportType_4();
		V_0 = L_0;
		int32_t L_1 = V_0;
		switch (((int32_t)il2cpp_codegen_subtract((int32_t)L_1, (int32_t)1)))
		{
			case 0:
			{
				goto IL_0022;
			}
			case 1:
			{
				goto IL_002e;
			}
		}
	}
	{
		goto IL_0066;
	}

IL_0022:
	{
		UdpServer_t2155BC92010633D56FBCDD33651BC3534AFBC2A2 * L_2 = __this->get_mUdpServer_9();
		NullCheck(L_2);
		UdpServer_Start_mFA80E493FFB5BDE21809C7850D598860E5B71E7D(L_2, /*hidden argument*/NULL);
		return;
	}

IL_002e:
	{
		TcpServer_tCE0D1B0600C9160AC6F845D86A878A42C5B08A17 * L_3 = __this->get_mTcpServer_10();
		ThreadStart_tA13019555BA3CB2B0128F0880760196BF790E687 * L_4 = (ThreadStart_tA13019555BA3CB2B0128F0880760196BF790E687 *)il2cpp_codegen_object_new(ThreadStart_tA13019555BA3CB2B0128F0880760196BF790E687_il2cpp_TypeInfo_var);
		ThreadStart__ctor_m360F4EED0AD96A27D6A9612BF79671F26B30411F(L_4, L_3, (intptr_t)((intptr_t)TcpServer_Start_mD4EF9EFDD7F305349C3C8B52B63CE46A45920A36_RuntimeMethod_var), /*hidden argument*/NULL);
		Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414 * L_5 = (Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414 *)il2cpp_codegen_object_new(Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414_il2cpp_TypeInfo_var);
		Thread__ctor_mF22465F0D0E47C11EF25DB552D1047402750BE90(L_5, L_4, /*hidden argument*/NULL);
		__this->set_mTcpServerThread_11(L_5);
		Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414 * L_6 = __this->get_mTcpServerThread_11();
		NullCheck(L_6);
		Thread_set_Name_m920049DFD1306F42613F13CF7AD74C03661F4BAE(L_6, _stringLiteral59D2C03D11B34581CD247E011280983E6284ED2D, /*hidden argument*/NULL);
		Thread_tB9EB71664220EE16451AF3276D78DE6614D2A414 * L_7 = __this->get_mTcpServerThread_11();
		NullCheck(L_7);
		Thread_Start_m490124B23F5EFD0BB2BED8CA12C77195B9CD9E1B(L_7, /*hidden argument*/NULL);
		return;
	}

IL_0066:
	{
		int32_t L_8 = __this->get_mTransportType_4();
		int32_t L_9 = L_8;
		RuntimeObject * L_10 = Box(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&TransportType_t19FD2303B5B680C76D1B24D778D0959E9AE8198C_il2cpp_TypeInfo_var)), &L_9);
		NullCheck(L_10);
		String_t* L_11;
		L_11 = VirtFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_10);
		String_t* L_12;
		L_12 = String_Concat_m4B4AB72618348C5DFBFBA8DED84B9E2EBDB55E1B(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral6CB20796A7CD300175C3C97D9D0B31A65326CA4E)), L_11, /*hidden argument*/NULL);
		InvalidOperationException_t10D3EE59AD28EC641ACEE05BCA4271A527E5ECAB * L_13 = (InvalidOperationException_t10D3EE59AD28EC641ACEE05BCA4271A527E5ECAB *)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t10D3EE59AD28EC641ACEE05BCA4271A527E5ECAB_il2cpp_TypeInfo_var)));
		InvalidOperationException__ctor_mC012CE552988309733C896F3FEA8249171E4402E(L_13, L_12, /*hidden argument*/NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_13, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&OscServer_Start_m1044E6A9E06A238BF97E02C480569E848250789E_RuntimeMethod_var)));
	}
}
// System.Void Bespoke.Common.Osc.OscServer::RegisterMethod(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer_RegisterMethod_m035A4CBB3C34F6D6537F1901920E3EBE76A94C0E (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, String_t* ___method0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Add_m627ED3F7C50096BB8934F778CB980E79483BD2AE_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Contains_m2EAD2DADA0478175052301E48FCE772ECD9A6F5F_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 * L_0 = __this->get_mRegisteredMethods_12();
		String_t* L_1 = ___method0;
		NullCheck(L_0);
		bool L_2;
		L_2 = List_1_Contains_m2EAD2DADA0478175052301E48FCE772ECD9A6F5F(L_0, L_1, /*hidden argument*/List_1_Contains_m2EAD2DADA0478175052301E48FCE772ECD9A6F5F_RuntimeMethod_var);
		if (L_2)
		{
			goto IL_001a;
		}
	}
	{
		List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 * L_3 = __this->get_mRegisteredMethods_12();
		String_t* L_4 = ___method0;
		NullCheck(L_3);
		List_1_Add_m627ED3F7C50096BB8934F778CB980E79483BD2AE(L_3, L_4, /*hidden argument*/List_1_Add_m627ED3F7C50096BB8934F778CB980E79483BD2AE_RuntimeMethod_var);
	}

IL_001a:
	{
		return;
	}
}
// System.Void Bespoke.Common.Osc.OscServer::mUdpServer_DataReceived(System.Object,Bespoke.Common.Net.UdpDataReceivedEventArgs)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer_mUdpServer_DataReceived_mA52B3AF0ABC91329EF251A4092268301E472E57B (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, RuntimeObject * ___sender0, UdpDataReceivedEventArgs_t148E7E67B81BD9271877379526876EBCA1A0B7F0 * ___e1, const RuntimeMethod* method)
{
	{
		UdpDataReceivedEventArgs_t148E7E67B81BD9271877379526876EBCA1A0B7F0 * L_0 = ___e1;
		NullCheck(L_0);
		IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * L_1;
		L_1 = UdpDataReceivedEventArgs_get_SourceEndPoint_mED1CFBC4279CE8D12B4FE602FF2CBAA4B84739B5_inline(L_0, /*hidden argument*/NULL);
		UdpDataReceivedEventArgs_t148E7E67B81BD9271877379526876EBCA1A0B7F0 * L_2 = ___e1;
		NullCheck(L_2);
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_3;
		L_3 = UdpDataReceivedEventArgs_get_Data_mBC575440F2AD896A6FA31CF042BF2B2559CBC832_inline(L_2, /*hidden argument*/NULL);
		OscServer_DataReceived_m911BC3E54D091A851D1DAB3FFB70444BBF47D64E(__this, L_1, L_3, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Bespoke.Common.Osc.OscServer::mTcpServer_DataReceived(System.Object,Bespoke.Common.Net.TcpDataReceivedEventArgs)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer_mTcpServer_DataReceived_mF3226741BBCC4C27878F698FA408C98E5A970DC2 (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, RuntimeObject * ___sender0, TcpDataReceivedEventArgs_t2A59DD027A324B15BAE90E0AC00122E825EDF4B3 * ___e1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		TcpDataReceivedEventArgs_t2A59DD027A324B15BAE90E0AC00122E825EDF4B3 * L_0 = ___e1;
		NullCheck(L_0);
		TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129 * L_1;
		L_1 = TcpDataReceivedEventArgs_get_Connection_m3E0F9BB18CE66DFC5AB97837917E6AF2033F040C_inline(L_0, /*hidden argument*/NULL);
		NullCheck(L_1);
		Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09 * L_2;
		L_2 = TcpConnection_get_Client_m1105A1E357094D0B4306B0BCA740CAB6609D3DB7_inline(L_1, /*hidden argument*/NULL);
		NullCheck(L_2);
		EndPoint_t18D4AE8D03090A2B262136E59F95CE61418C34DA * L_3;
		L_3 = Socket_get_RemoteEndPoint_m262E08E8CD25A908CB87450FC73683AB9DF636A7(L_2, /*hidden argument*/NULL);
		TcpDataReceivedEventArgs_t2A59DD027A324B15BAE90E0AC00122E825EDF4B3 * L_4 = ___e1;
		NullCheck(L_4);
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_5;
		L_5 = TcpDataReceivedEventArgs_get_Data_m309F675CADCD367023442B21705B2D4E70851769_inline(L_4, /*hidden argument*/NULL);
		OscServer_DataReceived_m911BC3E54D091A851D1DAB3FFB70444BBF47D64E(__this, ((IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E *)CastclassClass((RuntimeObject*)L_3, IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E_il2cpp_TypeInfo_var)), L_5, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Bespoke.Common.Osc.OscServer::DataReceived(System.Net.IPEndPoint,System.Byte[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer_DataReceived_m911BC3E54D091A851D1DAB3FFB70444BBF47D64E (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * ___sourceEndPoint0, ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Contains_m2EAD2DADA0478175052301E48FCE772ECD9A6F5F_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * V_0 = NULL;
	Exception_t * V_1 = NULL;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	il2cpp::utils::ExceptionSupportStack<int32_t, 2> __leave_targets;
	{
		bool L_0 = __this->get_mHandleMessages_15();
		il2cpp_codegen_memory_barrier();
		if (!L_0)
		{
			goto IL_0078;
		}
	}

IL_000a:
	try
	{ // begin try (depth: 1)
		{
			IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * L_1 = ___sourceEndPoint0;
			ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_2 = ___data1;
			IL2CPP_RUNTIME_CLASS_INIT(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
			OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * L_3;
			L_3 = OscPacket_FromByteArray_mF4ADF635CE40A8B3A3D1BFD76C69292817E94320(L_1, L_2, /*hidden argument*/NULL);
			V_0 = L_3;
			OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * L_4 = V_0;
			OscServer_OnPacketReceived_m860D1520295C31E85D109BAA3DAD84506A3F273E(__this, L_4, /*hidden argument*/NULL);
			OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * L_5 = V_0;
			NullCheck(L_5);
			bool L_6;
			L_6 = VirtFuncInvoker0< bool >::Invoke(4 /* System.Boolean Bespoke.Common.Osc.OscPacket::get_IsBundle() */, L_5);
			if (!L_6)
			{
				goto IL_002f;
			}
		}

IL_0021:
		{
			OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * L_7 = V_0;
			OscServer_OnBundleReceived_mF7A7CD601531F774FD91AFB8B96FD66703348D63(__this, ((OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 *)IsInstSealed((RuntimeObject*)L_7, OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41_il2cpp_TypeInfo_var)), /*hidden argument*/NULL);
			goto IL_0064;
		}

IL_002f:
		{
			bool L_8 = __this->get_mFilterRegisteredMethods_13();
			if (!L_8)
			{
				goto IL_0058;
			}
		}

IL_0037:
		{
			List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 * L_9 = __this->get_mRegisteredMethods_12();
			OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * L_10 = V_0;
			NullCheck(L_10);
			String_t* L_11;
			L_11 = OscPacket_get_Address_mD45518659033C523F1F8B38447C0FA5F52B3C1B5_inline(L_10, /*hidden argument*/NULL);
			NullCheck(L_9);
			bool L_12;
			L_12 = List_1_Contains_m2EAD2DADA0478175052301E48FCE772ECD9A6F5F(L_9, L_11, /*hidden argument*/List_1_Contains_m2EAD2DADA0478175052301E48FCE772ECD9A6F5F_RuntimeMethod_var);
			if (!L_12)
			{
				goto IL_0064;
			}
		}

IL_004a:
		{
			OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * L_13 = V_0;
			OscServer_OnMessageReceived_m86B75EBC89384DA4515224BCE58FBF7F39940E9B(__this, ((OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 *)IsInstClass((RuntimeObject*)L_13, OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2_il2cpp_TypeInfo_var)), /*hidden argument*/NULL);
			goto IL_0064;
		}

IL_0058:
		{
			OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * L_14 = V_0;
			OscServer_OnMessageReceived_m86B75EBC89384DA4515224BCE58FBF7F39940E9B(__this, ((OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 *)IsInstClass((RuntimeObject*)L_14, OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2_il2cpp_TypeInfo_var)), /*hidden argument*/NULL);
		}

IL_0064:
		{
			goto IL_0078;
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Exception_t_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0066;
		}
		throw e;
	}

CATCH_0066:
	{ // begin catch(System.Exception)
		{
			V_1 = ((Exception_t *)IL2CPP_GET_ACTIVE_EXCEPTION(Exception_t *));
			bool L_15 = __this->get_mConsumeParsingExceptions_16();
			if (L_15)
			{
				goto IL_0076;
			}
		}

IL_006f:
		{
			Exception_t * L_16 = V_1;
			OscServer_OnReceiveErrored_m5131D10379E290CEB442E918C058D9140F2F257E(__this, L_16, /*hidden argument*/NULL);
		}

IL_0076:
		{
			IL2CPP_POP_ACTIVE_EXCEPTION();
			goto IL_0078;
		}
	} // end catch (depth: 1)

IL_0078:
	{
		return;
	}
}
// System.Void Bespoke.Common.Osc.OscServer::OnPacketReceived(Bespoke.Common.Osc.OscPacket)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer_OnPacketReceived_m860D1520295C31E85D109BAA3DAD84506A3F273E (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * ___packet0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EventHandler_1_Invoke_mE2206F76F47AF2795139FCA29519AA990016BEC4_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacketReceivedEventArgs_t61CB29F943015645037B535D6348EA15E19C680B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		EventHandler_1_t0AFB60D05E9FCFB34BD7F25226CC0CEE2E7271E4 * L_0 = __this->get_PacketReceived_0();
		if (!L_0)
		{
			goto IL_001a;
		}
	}
	{
		EventHandler_1_t0AFB60D05E9FCFB34BD7F25226CC0CEE2E7271E4 * L_1 = __this->get_PacketReceived_0();
		OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * L_2 = ___packet0;
		OscPacketReceivedEventArgs_t61CB29F943015645037B535D6348EA15E19C680B * L_3 = (OscPacketReceivedEventArgs_t61CB29F943015645037B535D6348EA15E19C680B *)il2cpp_codegen_object_new(OscPacketReceivedEventArgs_t61CB29F943015645037B535D6348EA15E19C680B_il2cpp_TypeInfo_var);
		OscPacketReceivedEventArgs__ctor_mCBE38234059260263BE854F6BC0528E4456189FF(L_3, L_2, /*hidden argument*/NULL);
		NullCheck(L_1);
		EventHandler_1_Invoke_mE2206F76F47AF2795139FCA29519AA990016BEC4(L_1, __this, L_3, /*hidden argument*/EventHandler_1_Invoke_mE2206F76F47AF2795139FCA29519AA990016BEC4_RuntimeMethod_var);
	}

IL_001a:
	{
		return;
	}
}
// System.Void Bespoke.Common.Osc.OscServer::OnBundleReceived(Bespoke.Common.Osc.OscBundle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer_OnBundleReceived_mF7A7CD601531F774FD91AFB8B96FD66703348D63 (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * ___bundle0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EventHandler_1_Invoke_m9FBD0C6547BE3E0181C257B21FC575BF296A5205_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IDisposable_t099785737FC6A1E3699919A94109383715A8D807_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IEnumerable_1_t52B1AC8D9E5E1ED28DF6C46A37C9A1B00B394F9D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IEnumerator_1_t2DC97C7D486BF9E077C2BC2E517E434F393AA76E_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IEnumerator_t5956F3AFB7ECF1117E3BC5890E7FC7B7F7A04105_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Contains_m2EAD2DADA0478175052301E48FCE772ECD9A6F5F_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscBundleReceivedEventArgs_t1ABF2F51A974BCF1B4328DCA66A094C2D6AB6345_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	RuntimeObject * V_0 = NULL;
	OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * V_1 = NULL;
	RuntimeObject* V_2 = NULL;
	Exception_t * __last_unhandled_exception = 0;
	il2cpp::utils::ExceptionSupportStack<int32_t, 1> __leave_targets;
	{
		EventHandler_1_t129E585D9AA40035BC8D64CA9AE2FB4166FD9AC4 * L_0 = __this->get_BundleReceived_1();
		if (!L_0)
		{
			goto IL_0096;
		}
	}
	{
		EventHandler_1_t129E585D9AA40035BC8D64CA9AE2FB4166FD9AC4 * L_1 = __this->get_BundleReceived_1();
		OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * L_2 = ___bundle0;
		OscBundleReceivedEventArgs_t1ABF2F51A974BCF1B4328DCA66A094C2D6AB6345 * L_3 = (OscBundleReceivedEventArgs_t1ABF2F51A974BCF1B4328DCA66A094C2D6AB6345 *)il2cpp_codegen_object_new(OscBundleReceivedEventArgs_t1ABF2F51A974BCF1B4328DCA66A094C2D6AB6345_il2cpp_TypeInfo_var);
		OscBundleReceivedEventArgs__ctor_m6F728FD0758DC5D906D5EA29E795A90445005355(L_3, L_2, /*hidden argument*/NULL);
		NullCheck(L_1);
		EventHandler_1_Invoke_m9FBD0C6547BE3E0181C257B21FC575BF296A5205(L_1, __this, L_3, /*hidden argument*/EventHandler_1_Invoke_m9FBD0C6547BE3E0181C257B21FC575BF296A5205_RuntimeMethod_var);
		OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 * L_4 = ___bundle0;
		NullCheck(L_4);
		RuntimeObject* L_5;
		L_5 = OscPacket_get_Data_mD670EFFAF7A2F1D60A157BB958512515DAAF92FA(L_4, /*hidden argument*/NULL);
		NullCheck(L_5);
		RuntimeObject* L_6;
		L_6 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0 /* System.Collections.Generic.IEnumerator`1<!0> System.Collections.Generic.IEnumerable`1<System.Object>::GetEnumerator() */, IEnumerable_1_t52B1AC8D9E5E1ED28DF6C46A37C9A1B00B394F9D_il2cpp_TypeInfo_var, L_5);
		V_2 = L_6;
	}

IL_0029:
	try
	{ // begin try (depth: 1)
		{
			goto IL_0082;
		}

IL_002b:
		{
			RuntimeObject* L_7 = V_2;
			NullCheck(L_7);
			RuntimeObject * L_8;
			L_8 = InterfaceFuncInvoker0< RuntimeObject * >::Invoke(0 /* !0 System.Collections.Generic.IEnumerator`1<System.Object>::get_Current() */, IEnumerator_1_t2DC97C7D486BF9E077C2BC2E517E434F393AA76E_il2cpp_TypeInfo_var, L_7);
			V_0 = L_8;
			RuntimeObject * L_9 = V_0;
			if (!((OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 *)IsInstSealed((RuntimeObject*)L_9, OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41_il2cpp_TypeInfo_var)))
			{
				goto IL_0048;
			}
		}

IL_003a:
		{
			RuntimeObject * L_10 = V_0;
			OscServer_OnBundleReceived_mF7A7CD601531F774FD91AFB8B96FD66703348D63(__this, ((OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41 *)CastclassSealed((RuntimeObject*)L_10, OscBundle_tAEBBFCEBC270CE7D2DFC970BEF0B16FDA7A3AE41_il2cpp_TypeInfo_var)), /*hidden argument*/NULL);
			goto IL_0082;
		}

IL_0048:
		{
			RuntimeObject * L_11 = V_0;
			if (!((OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 *)IsInstClass((RuntimeObject*)L_11, OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2_il2cpp_TypeInfo_var)))
			{
				goto IL_0082;
			}
		}

IL_0050:
		{
			RuntimeObject * L_12 = V_0;
			V_1 = ((OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 *)CastclassClass((RuntimeObject*)L_12, OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2_il2cpp_TypeInfo_var));
			bool L_13 = __this->get_mFilterRegisteredMethods_13();
			if (!L_13)
			{
				goto IL_007b;
			}
		}

IL_005f:
		{
			List_1_t6C9F81EDBF0F4A31A9B0DA372D2EF34BDA3A1AF3 * L_14 = __this->get_mRegisteredMethods_12();
			OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * L_15 = V_1;
			NullCheck(L_15);
			String_t* L_16;
			L_16 = OscPacket_get_Address_mD45518659033C523F1F8B38447C0FA5F52B3C1B5_inline(L_15, /*hidden argument*/NULL);
			NullCheck(L_14);
			bool L_17;
			L_17 = List_1_Contains_m2EAD2DADA0478175052301E48FCE772ECD9A6F5F(L_14, L_16, /*hidden argument*/List_1_Contains_m2EAD2DADA0478175052301E48FCE772ECD9A6F5F_RuntimeMethod_var);
			if (!L_17)
			{
				goto IL_0082;
			}
		}

IL_0072:
		{
			OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * L_18 = V_1;
			OscServer_OnMessageReceived_m86B75EBC89384DA4515224BCE58FBF7F39940E9B(__this, L_18, /*hidden argument*/NULL);
			goto IL_0082;
		}

IL_007b:
		{
			OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * L_19 = V_1;
			OscServer_OnMessageReceived_m86B75EBC89384DA4515224BCE58FBF7F39940E9B(__this, L_19, /*hidden argument*/NULL);
		}

IL_0082:
		{
			RuntimeObject* L_20 = V_2;
			NullCheck(L_20);
			bool L_21;
			L_21 = InterfaceFuncInvoker0< bool >::Invoke(0 /* System.Boolean System.Collections.IEnumerator::MoveNext() */, IEnumerator_t5956F3AFB7ECF1117E3BC5890E7FC7B7F7A04105_il2cpp_TypeInfo_var, L_20);
			if (L_21)
			{
				goto IL_002b;
			}
		}

IL_008a:
		{
			IL2CPP_LEAVE(0x96, FINALLY_008c);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t *)e.ex;
		goto FINALLY_008c;
	}

FINALLY_008c:
	{ // begin finally (depth: 1)
		{
			RuntimeObject* L_22 = V_2;
			if (!L_22)
			{
				goto IL_0095;
			}
		}

IL_008f:
		{
			RuntimeObject* L_23 = V_2;
			NullCheck(L_23);
			InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t099785737FC6A1E3699919A94109383715A8D807_il2cpp_TypeInfo_var, L_23);
		}

IL_0095:
		{
			IL2CPP_END_FINALLY(140)
		}
	} // end finally (depth: 1)
	IL2CPP_CLEANUP(140)
	{
		IL2CPP_RETHROW_IF_UNHANDLED(Exception_t *)
		IL2CPP_JUMP_TBL(0x96, IL_0096)
	}

IL_0096:
	{
		return;
	}
}
// System.Void Bespoke.Common.Osc.OscServer::OnMessageReceived(Bespoke.Common.Osc.OscMessage)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer_OnMessageReceived_m86B75EBC89384DA4515224BCE58FBF7F39940E9B (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * ___message0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EventHandler_1_Invoke_mC992C9DD6820DCE0E81AC4354254266855395E44_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscMessageReceivedEventArgs_t8E8CE6EC7E84AF0892F400AB363313C22B8C4E83_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * L_0 = __this->get_MessageReceived_2();
		if (!L_0)
		{
			goto IL_001a;
		}
	}
	{
		EventHandler_1_t5C56ECAF6974E3D8748359D220D91DFEB84D1714 * L_1 = __this->get_MessageReceived_2();
		OscMessage_t41F712E311F7F8146BDE58B7B15EDF71F05A90A2 * L_2 = ___message0;
		OscMessageReceivedEventArgs_t8E8CE6EC7E84AF0892F400AB363313C22B8C4E83 * L_3 = (OscMessageReceivedEventArgs_t8E8CE6EC7E84AF0892F400AB363313C22B8C4E83 *)il2cpp_codegen_object_new(OscMessageReceivedEventArgs_t8E8CE6EC7E84AF0892F400AB363313C22B8C4E83_il2cpp_TypeInfo_var);
		OscMessageReceivedEventArgs__ctor_mFDDFFCCE818650EE040AB7BF15C2D2B24945C84B(L_3, L_2, /*hidden argument*/NULL);
		NullCheck(L_1);
		EventHandler_1_Invoke_mC992C9DD6820DCE0E81AC4354254266855395E44(L_1, __this, L_3, /*hidden argument*/EventHandler_1_Invoke_mC992C9DD6820DCE0E81AC4354254266855395E44_RuntimeMethod_var);
	}

IL_001a:
	{
		return;
	}
}
// System.Void Bespoke.Common.Osc.OscServer::OnReceiveErrored(System.Exception)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscServer_OnReceiveErrored_m5131D10379E290CEB442E918C058D9140F2F257E (OscServer_tEC9090B8C05007FBB204BE388A8707862015E025 * __this, Exception_t * ___ex0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EventHandler_1_Invoke_mDAF40BCF69918DFB2E3A7C5006658EBD7B6DFA22_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ExceptionEventArgs_t1207BC0BED111D8BEA61607413C2A139F8A1DDC0_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * L_0 = __this->get_ReceiveErrored_3();
		if (!L_0)
		{
			goto IL_001a;
		}
	}
	{
		EventHandler_1_t7453E48435E2F87887900D335E372C349E37A81F * L_1 = __this->get_ReceiveErrored_3();
		Exception_t * L_2 = ___ex0;
		ExceptionEventArgs_t1207BC0BED111D8BEA61607413C2A139F8A1DDC0 * L_3 = (ExceptionEventArgs_t1207BC0BED111D8BEA61607413C2A139F8A1DDC0 *)il2cpp_codegen_object_new(ExceptionEventArgs_t1207BC0BED111D8BEA61607413C2A139F8A1DDC0_il2cpp_TypeInfo_var);
		ExceptionEventArgs__ctor_mB5208F480F27F45719DBEC4931AC356B7FE222AA(L_3, L_2, /*hidden argument*/NULL);
		NullCheck(L_1);
		EventHandler_1_Invoke_mDAF40BCF69918DFB2E3A7C5006658EBD7B6DFA22(L_1, __this, L_3, /*hidden argument*/EventHandler_1_Invoke_mDAF40BCF69918DFB2E3A7C5006658EBD7B6DFA22_RuntimeMethod_var);
	}

IL_001a:
	{
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.DateTime Bespoke.Common.Osc.OscTimeTag::get_DateTime()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  OscTimeTag_get_DateTime_mAD491347C2C6C24AA2FC6B03E263683756EFDF25 (OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * __this, const RuntimeMethod* method)
{
	{
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_0 = __this->get_mTimeStamp_2();
		return L_0;
	}
}
// System.Void Bespoke.Common.Osc.OscTimeTag::.ctor(System.DateTime)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscTimeTag__ctor_mCB193BCB3F611E61B03FE5FEFF2791B367B5CE61 (OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * __this, DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  ___timeStamp0, const RuntimeMethod* method)
{
	{
		Object__ctor_m88880E0413421D13FD95325EDCE231707CE1F405(__this, /*hidden argument*/NULL);
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_0 = ___timeStamp0;
		OscTimeTag_Set_m7B9425997597C968F6C96307FF720A29946F6C4A(__this, L_0, /*hidden argument*/NULL);
		return;
	}
}
// System.Void Bespoke.Common.Osc.OscTimeTag::.ctor(System.Byte[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscTimeTag__ctor_mC25A49CB5BB8217EF60EF61CF632B9A616ACFA9B (OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * __this, ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* ___data0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t8DCBA24B909F1B221372AF2B37C76DCF614BA654_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_CopySubArray_TisByte_t0111FAB8B8685667EDDAF77683F0D8F86B659056_m34AF4999A31EB9E8E03253BAF85132FF9341AC35_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* V_0 = NULL;
	ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* V_1 = NULL;
	uint32_t V_2 = 0;
	uint32_t V_3 = 0;
	DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  V_4;
	memset((&V_4), 0, sizeof(V_4));
	DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  V_5;
	memset((&V_5), 0, sizeof(V_5));
	DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  V_6;
	memset((&V_6), 0, sizeof(V_6));
	{
		Object__ctor_m88880E0413421D13FD95325EDCE231707CE1F405(__this, /*hidden argument*/NULL);
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_0 = ___data0;
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_1;
		L_1 = Utility_CopySubArray_TisByte_t0111FAB8B8685667EDDAF77683F0D8F86B659056_m34AF4999A31EB9E8E03253BAF85132FF9341AC35(L_0, 0, 4, /*hidden argument*/Utility_CopySubArray_TisByte_t0111FAB8B8685667EDDAF77683F0D8F86B659056_m34AF4999A31EB9E8E03253BAF85132FF9341AC35_RuntimeMethod_var);
		V_0 = L_1;
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_2 = ___data0;
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_3;
		L_3 = Utility_CopySubArray_TisByte_t0111FAB8B8685667EDDAF77683F0D8F86B659056_m34AF4999A31EB9E8E03253BAF85132FF9341AC35(L_2, 4, 4, /*hidden argument*/Utility_CopySubArray_TisByte_t0111FAB8B8685667EDDAF77683F0D8F86B659056_m34AF4999A31EB9E8E03253BAF85132FF9341AC35_RuntimeMethod_var);
		V_1 = L_3;
		IL2CPP_RUNTIME_CLASS_INIT(BitConverter_t8DCBA24B909F1B221372AF2B37C76DCF614BA654_il2cpp_TypeInfo_var);
		bool L_4 = ((BitConverter_t8DCBA24B909F1B221372AF2B37C76DCF614BA654_StaticFields*)il2cpp_codegen_static_fields_for(BitConverter_t8DCBA24B909F1B221372AF2B37C76DCF614BA654_il2cpp_TypeInfo_var))->get_IsLittleEndian_0();
		IL2CPP_RUNTIME_CLASS_INIT(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		bool L_5;
		L_5 = OscPacket_get_LittleEndianByteOrder_mAD90FE000F92E9C98C43812B33653B589A84AAF1_inline(/*hidden argument*/NULL);
		if ((((int32_t)L_4) == ((int32_t)L_5)))
		{
			goto IL_0032;
		}
	}
	{
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_6 = V_0;
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_7;
		L_7 = Utility_SwapEndian_mFE91837F95B070E0A498234341F4613EB00F11B1(L_6, /*hidden argument*/NULL);
		V_0 = L_7;
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_8 = V_1;
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_9;
		L_9 = Utility_SwapEndian_mFE91837F95B070E0A498234341F4613EB00F11B1(L_8, /*hidden argument*/NULL);
		V_1 = L_9;
	}

IL_0032:
	{
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_10 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(BitConverter_t8DCBA24B909F1B221372AF2B37C76DCF614BA654_il2cpp_TypeInfo_var);
		uint32_t L_11;
		L_11 = BitConverter_ToUInt32_m0C9F3D9840110CC82D4C18FD882AC5C7EA595366(L_10, 0, /*hidden argument*/NULL);
		V_2 = L_11;
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_12 = V_1;
		uint32_t L_13;
		L_13 = BitConverter_ToUInt32_m0C9F3D9840110CC82D4C18FD882AC5C7EA595366(L_12, 0, /*hidden argument*/NULL);
		V_3 = L_13;
		IL2CPP_RUNTIME_CLASS_INIT(OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_il2cpp_TypeInfo_var);
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_14 = ((OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_StaticFields*)il2cpp_codegen_static_fields_for(OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_il2cpp_TypeInfo_var))->get_Epoch_0();
		V_5 = L_14;
		uint32_t L_15 = V_2;
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_16;
		L_16 = DateTime_AddSeconds_mCA0940A7E7C3ED40A86532349B7D4CB3A0F0DEAF((DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 *)(&V_5), ((double)((double)((double)((uint32_t)L_15)))), /*hidden argument*/NULL);
		V_6 = L_16;
		uint32_t L_17 = V_3;
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_18;
		L_18 = DateTime_AddMilliseconds_m74B689CDAFB7ABEEF56827D8777B7C95C89C3154((DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 *)(&V_6), ((double)((double)((double)((uint32_t)L_17)))), /*hidden argument*/NULL);
		V_4 = L_18;
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_19 = V_4;
		bool L_20;
		L_20 = OscTimeTag_IsValidTime_m6F67C8A47A42584D6F8F1D61E5AAECB5E3BC6489(L_19, /*hidden argument*/NULL);
		Assert_IsTrue_m1ABA281F642FE8A1C9F08DC02CA7B757B5D0C2AE(L_20, /*hidden argument*/NULL);
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_21 = V_4;
		__this->set_mTimeStamp_2(L_21);
		return;
	}
}
// System.Boolean Bespoke.Common.Osc.OscTimeTag::op_Equality(Bespoke.Common.Osc.OscTimeTag,Bespoke.Common.Osc.OscTimeTag)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool OscTimeTag_op_Equality_m65F04723AA02BAEE8D919C71053C0968633DF730 (OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * ___lhs0, OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * ___rhs1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * L_0 = ___lhs0;
		OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * L_1 = ___rhs1;
		bool L_2;
		L_2 = il2cpp_codegen_object_reference_equals(L_0, L_1);
		if (!L_2)
		{
			goto IL_000b;
		}
	}
	{
		return (bool)1;
	}

IL_000b:
	{
		OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * L_3 = ___lhs0;
		if (!L_3)
		{
			goto IL_0011;
		}
	}
	{
		OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * L_4 = ___rhs1;
		if (L_4)
		{
			goto IL_0013;
		}
	}

IL_0011:
	{
		return (bool)0;
	}

IL_0013:
	{
		OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * L_5 = ___lhs0;
		NullCheck(L_5);
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_6;
		L_6 = OscTimeTag_get_DateTime_mAD491347C2C6C24AA2FC6B03E263683756EFDF25_inline(L_5, /*hidden argument*/NULL);
		OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * L_7 = ___rhs1;
		NullCheck(L_7);
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_8;
		L_8 = OscTimeTag_get_DateTime_mAD491347C2C6C24AA2FC6B03E263683756EFDF25_inline(L_7, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405_il2cpp_TypeInfo_var);
		bool L_9;
		L_9 = DateTime_op_Equality_m07957AECB8C66EA047B16511BF560DD9EDA1DA44(L_6, L_8, /*hidden argument*/NULL);
		return L_9;
	}
}
// System.Boolean Bespoke.Common.Osc.OscTimeTag::op_GreaterThanOrEqual(Bespoke.Common.Osc.OscTimeTag,Bespoke.Common.Osc.OscTimeTag)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool OscTimeTag_op_GreaterThanOrEqual_mAE4281C4FF52FFDC14204509EAE56DB379A45372 (OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * ___lhs0, OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * ___rhs1, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * L_0 = ___lhs0;
		NullCheck(L_0);
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_1;
		L_1 = OscTimeTag_get_DateTime_mAD491347C2C6C24AA2FC6B03E263683756EFDF25_inline(L_0, /*hidden argument*/NULL);
		OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * L_2 = ___rhs1;
		NullCheck(L_2);
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_3;
		L_3 = OscTimeTag_get_DateTime_mAD491347C2C6C24AA2FC6B03E263683756EFDF25_inline(L_2, /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405_il2cpp_TypeInfo_var);
		bool L_4;
		L_4 = DateTime_op_GreaterThanOrEqual_mB7C78A9E8E0004F447A9E2735FB33E20005C96C0(L_1, L_3, /*hidden argument*/NULL);
		return L_4;
	}
}
// System.Boolean Bespoke.Common.Osc.OscTimeTag::IsValidTime(System.DateTime)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool OscTimeTag_IsValidTime_m6F67C8A47A42584D6F8F1D61E5AAECB5E3BC6489 (DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  ___timeStamp0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_0 = ___timeStamp0;
		IL2CPP_RUNTIME_CLASS_INIT(OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_il2cpp_TypeInfo_var);
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_1 = ((OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_StaticFields*)il2cpp_codegen_static_fields_for(OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_il2cpp_TypeInfo_var))->get_Epoch_0();
		IL2CPP_RUNTIME_CLASS_INIT(TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203_il2cpp_TypeInfo_var);
		TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203  L_2;
		L_2 = TimeSpan_FromMilliseconds_m12D90542B044C450FDFBCEA1CBC32369479483EC((1.0), /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405_il2cpp_TypeInfo_var);
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_3;
		L_3 = DateTime_op_Addition_m7EDD5204F9E1BCE2C13DE0064417BCA04418BC14(L_1, L_2, /*hidden argument*/NULL);
		bool L_4;
		L_4 = DateTime_op_GreaterThanOrEqual_mB7C78A9E8E0004F447A9E2735FB33E20005C96C0(L_0, L_3, /*hidden argument*/NULL);
		return L_4;
	}
}
// System.Void Bespoke.Common.Osc.OscTimeTag::Set(System.DateTime)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscTimeTag_Set_m7B9425997597C968F6C96307FF720A29946F6C4A (OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * __this, DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  ___timeStamp0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		int64_t L_0;
		L_0 = DateTime_get_Ticks_m175EDB41A50DB06872CC48CAB603FEBD1DFF46A9((DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 *)(&___timeStamp0), /*hidden argument*/NULL);
		int64_t L_1;
		L_1 = DateTime_get_Ticks_m175EDB41A50DB06872CC48CAB603FEBD1DFF46A9((DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 *)(&___timeStamp0), /*hidden argument*/NULL);
		int32_t L_2;
		L_2 = DateTime_get_Kind_mC7EC1A788CC9A875094117214C5A0C153A39F496((DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 *)(&___timeStamp0), /*hidden argument*/NULL);
		DateTime__ctor_mD17BC147184B06220C3FD44EBF50238A3894ADD7((DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 *)(&___timeStamp0), ((int64_t)il2cpp_codegen_subtract((int64_t)L_0, (int64_t)((int64_t)((int64_t)L_1%(int64_t)((int64_t)((int64_t)((int32_t)10000))))))), L_2, /*hidden argument*/NULL);
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_3 = ___timeStamp0;
		IL2CPP_RUNTIME_CLASS_INIT(OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_il2cpp_TypeInfo_var);
		bool L_4;
		L_4 = OscTimeTag_IsValidTime_m6F67C8A47A42584D6F8F1D61E5AAECB5E3BC6489(L_3, /*hidden argument*/NULL);
		Assert_IsTrue_m1ABA281F642FE8A1C9F08DC02CA7B757B5D0C2AE(L_4, /*hidden argument*/NULL);
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_5 = ___timeStamp0;
		__this->set_mTimeStamp_2(L_5);
		return;
	}
}
// System.Boolean Bespoke.Common.Osc.OscTimeTag::Equals(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool OscTimeTag_Equals_m9082BD212872395B553F68C58B7BDBE2B7A9E36F (OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * __this, RuntimeObject * ___value0, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * V_0 = NULL;
	{
		RuntimeObject * L_0 = ___value0;
		if (L_0)
		{
			goto IL_0005;
		}
	}
	{
		return (bool)0;
	}

IL_0005:
	{
		RuntimeObject * L_1 = ___value0;
		V_0 = ((OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB *)IsInstClass((RuntimeObject*)L_1, OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_il2cpp_TypeInfo_var));
		OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * L_2 = V_0;
		IL2CPP_RUNTIME_CLASS_INIT(OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_il2cpp_TypeInfo_var);
		bool L_3;
		L_3 = OscTimeTag_op_Equality_m65F04723AA02BAEE8D919C71053C0968633DF730(L_2, (OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB *)NULL, /*hidden argument*/NULL);
		if (!L_3)
		{
			goto IL_0017;
		}
	}
	{
		return (bool)0;
	}

IL_0017:
	{
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 * L_4 = __this->get_address_of_mTimeStamp_2();
		OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * L_5 = V_0;
		NullCheck(L_5);
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_6 = L_5->get_mTimeStamp_2();
		bool L_7;
		L_7 = DateTime_Equals_m22392E29066D685DB7DD20CB022B101E0CC244EA((DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 *)L_4, L_6, /*hidden argument*/NULL);
		return L_7;
	}
}
// System.Int32 Bespoke.Common.Osc.OscTimeTag::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t OscTimeTag_GetHashCode_m70C32C434AD28348FF896956B1CB9F19990A32A2 (OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * __this, const RuntimeMethod* method)
{
	{
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 * L_0 = __this->get_address_of_mTimeStamp_2();
		int32_t L_1;
		L_1 = DateTime_GetHashCode_mC94DC52667BB5C0DE7A78C53BE24FDF5469BA49D((DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 *)L_0, /*hidden argument*/NULL);
		return L_1;
	}
}
// System.String Bespoke.Common.Osc.OscTimeTag::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* OscTimeTag_ToString_m74EB79B43328DCAB94AB01F36D0F6388949C707F (OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * __this, const RuntimeMethod* method)
{
	{
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 * L_0 = __this->get_address_of_mTimeStamp_2();
		String_t* L_1;
		L_1 = DateTime_ToString_m242888E500DFD8CD675BDC455BC696AF47813954((DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405 *)L_0, /*hidden argument*/NULL);
		return L_1;
	}
}
// System.Void Bespoke.Common.Osc.OscTimeTag::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void OscTimeTag__cctor_m69575C39684AFD891BCCFDFAB091375645493BA7 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_0;
		memset((&L_0), 0, sizeof(L_0));
		DateTime__ctor_m0FFFFEA32E380156E1FB4224D50CD0B16707E61C((&L_0), ((int32_t)1900), 1, 1, 0, 0, 0, 0, /*hidden argument*/NULL);
		((OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_StaticFields*)il2cpp_codegen_static_fields_for(OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_il2cpp_TypeInfo_var))->set_Epoch_0(L_0);
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_1 = ((OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_StaticFields*)il2cpp_codegen_static_fields_for(OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_il2cpp_TypeInfo_var))->get_Epoch_0();
		IL2CPP_RUNTIME_CLASS_INIT(TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203_il2cpp_TypeInfo_var);
		TimeSpan_t4F6A0E13E703B65365CFCAB58E05EE0AF3EE6203  L_2;
		L_2 = TimeSpan_FromMilliseconds_m12D90542B044C450FDFBCEA1CBC32369479483EC((1.0), /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405_il2cpp_TypeInfo_var);
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_3;
		L_3 = DateTime_op_Addition_m7EDD5204F9E1BCE2C13DE0064417BCA04418BC14(L_1, L_2, /*hidden argument*/NULL);
		OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * L_4 = (OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB *)il2cpp_codegen_object_new(OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_il2cpp_TypeInfo_var);
		OscTimeTag__ctor_mCB193BCB3F611E61B03FE5FEFF2791B367B5CE61(L_4, L_3, /*hidden argument*/NULL);
		((OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_StaticFields*)il2cpp_codegen_static_fields_for(OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB_il2cpp_TypeInfo_var))->set_MinValue_1(L_4);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool OscPacket_get_LittleEndianByteOrder_mAD90FE000F92E9C98C43812B33653B589A84AAF1_inline (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var);
		bool L_0 = ((OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_StaticFields*)il2cpp_codegen_static_fields_for(OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5_il2cpp_TypeInfo_var))->get_sLittleEndianByteOrder_0();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * UdpDataReceivedEventArgs_get_SourceEndPoint_mED1CFBC4279CE8D12B4FE602FF2CBAA4B84739B5_inline (UdpDataReceivedEventArgs_t148E7E67B81BD9271877379526876EBCA1A0B7F0 * __this, const RuntimeMethod* method)
{
	{
		IPEndPoint_t41C675C79A8B4EA6D5211D9B907137A2C015EA3E * L_0 = __this->get_mSourceEndPoint_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* UdpDataReceivedEventArgs_get_Data_mBC575440F2AD896A6FA31CF042BF2B2559CBC832_inline (UdpDataReceivedEventArgs_t148E7E67B81BD9271877379526876EBCA1A0B7F0 * __this, const RuntimeMethod* method)
{
	{
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_0 = __this->get_mData_2();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129 * TcpDataReceivedEventArgs_get_Connection_m3E0F9BB18CE66DFC5AB97837917E6AF2033F040C_inline (TcpDataReceivedEventArgs_t2A59DD027A324B15BAE90E0AC00122E825EDF4B3 * __this, const RuntimeMethod* method)
{
	{
		TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129 * L_0 = __this->get_mConnection_1();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09 * TcpConnection_get_Client_m1105A1E357094D0B4306B0BCA740CAB6609D3DB7_inline (TcpConnection_t9D20020148B3D3004F57023CF8D19C204EB02129 * __this, const RuntimeMethod* method)
{
	{
		Socket_tD9721140F91BE95BA05B87DD26A855B215D84D09 * L_0 = __this->get_mClient_3();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* TcpDataReceivedEventArgs_get_Data_m309F675CADCD367023442B21705B2D4E70851769_inline (TcpDataReceivedEventArgs_t2A59DD027A324B15BAE90E0AC00122E825EDF4B3 * __this, const RuntimeMethod* method)
{
	{
		ByteU5BU5D_tDBBEB0E8362242FA7223000D978B0DD19D4B0726* L_0 = __this->get_mData_2();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR String_t* OscPacket_get_Address_mD45518659033C523F1F8B38447C0FA5F52B3C1B5_inline (OscPacket_tFE7D78247E781070BAF0F85CAE283A07CDA702F5 * __this, const RuntimeMethod* method)
{
	{
		String_t* L_0 = __this->get_mAddress_2();
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  OscTimeTag_get_DateTime_mAD491347C2C6C24AA2FC6B03E263683756EFDF25_inline (OscTimeTag_tD32FD73F2608F48BFC0F3EA4EC4FF3F91CEFA1CB * __this, const RuntimeMethod* method)
{
	{
		DateTime_tEAF2CD16E071DF5441F40822E4CFE880E5245405  L_0 = __this->get_mTimeStamp_2();
		return L_0;
	}
}
