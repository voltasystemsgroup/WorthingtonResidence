using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;
using AffinityClientConnectionModule.Client;
using AffinityClientConnection.Client.Serial_Client_Interface;
using AffinityClientConnection.Client.Serial_Client_Interface.CRPC_Calls;
using AffinityClientConnection.Configuration;
using AffinityClientConnection.Logging;
using AffinityClientConnection;
using Crestron.Seawolf.CRPC.v2.Objects;
using Crestron.Seawolf.CRPC;
using Crestron.Seawolf.CRPC.v2.Messages.Exceptions;
using Crestron.Seawolf.CRPC.v2.Encodings;
using Crestron.Seawolf.CRPC.v2.Formats;
using Crestron.Seawolf.CRPC.v2.Messages;
using Crestron.Seawolf.CRPC.v2.Service;
using Crestron.Seawolf.CRPC.CrpcGenericClient;
using Crestron.Seawolf.CRPC.v2.Interfaces;
using Crestron.Seawolf.CRPC.CIPDirectTransport;
using Crestron.Seawolf.CRPC.Common.v2.Utilities;
using Crestron.Seawolf.CRPC.Common.Extensions;
using Crestron.Seawolf.CRPC.Common.v2.Messages.Objects;
using Crestron.Seawolf.CRPC.Common;
using Crestron.Seawolf.CRPC.Common.v2.Interfaces;

namespace CrestronModule_SERIAL_CLIENT_INTERFACE_V1_0
{
    public class CrestronModuleClass_SERIAL_CLIENT_INTERFACE_V1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput CONNECT;
        Crestron.Logos.SplusObjects.BufferInput CRPC_FROM_CLIENT;
        Crestron.Logos.SplusObjects.DigitalOutput SERVER_OFFLINE;
        Crestron.Logos.SplusObjects.StringOutput CRPC_TO_CLIENT;
        AffinityClientConnection.Client.Serial_Client_Interface.SerialClientInterface CRPCSERIALCLIENTCONNECTION;
        object CONNECT_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                 SerialInterfaceCRPCClient.Initialize()  ;  
 
                
                __context__.SourceCodeLine = 22;
                CRPCSERIALCLIENTCONNECTION . Initialize ( ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object CRPC_FROM_CLIENT_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            CrestronString CLIENTCRPCDATA;
            CLIENTCRPCDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 65534, this );
            
            CrestronString TEMPLENGTH;
            TEMPLENGTH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
            
            uint COMMANDLENGTH = 0;
            
            CrestronString HEADER;
            HEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
            
            
            __context__.SourceCodeLine = 32;
            while ( Functions.TestForTrue  ( ( 1)  ) ) 
                { 
                __context__.SourceCodeLine = 34;
                HEADER  .UpdateValue ( Functions.Gather ( 8, CRPC_FROM_CLIENT )  ) ; 
                __context__.SourceCodeLine = 36;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Atoi( Functions.Left( HEADER , (int)( 1 ) ) ) == 2))  ) ) 
                    { 
                    __context__.SourceCodeLine = 38;
                    TEMPLENGTH  .UpdateValue ( Functions.Right ( HEADER ,  (int) ( 4 ) )  ) ; 
                    __context__.SourceCodeLine = 39;
                    COMMANDLENGTH = (uint) ( Functions.HextoL( TEMPLENGTH ) ) ; 
                    __context__.SourceCodeLine = 40;
                    CLIENTCRPCDATA  .UpdateValue ( Functions.Gather ( Functions.LowWord( (uint)( COMMANDLENGTH ) ), CRPC_FROM_CLIENT )  ) ; 
                    __context__.SourceCodeLine = 42;
                    CLIENTCRPCDATA  .UpdateValue ( HEADER + CLIENTCRPCDATA  ) ; 
                    __context__.SourceCodeLine = 44;
                    CRPCSERIALCLIENTCONNECTION . ClientRx ( CLIENTCRPCDATA .ToString()) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 46;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Atoi( Functions.Left( HEADER , (int)( 1 ) ) ) == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 48;
                        GenerateUserError ( "CRPC Version 1 Detected.  Please Upgrade Core 3 Controls.") ; 
                        __context__.SourceCodeLine = 49;
                        Functions.ClearBuffer ( CRPC_FROM_CLIENT ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 53;
                        GenerateUserError ( "Unable to process client CRPC message.  Version: {0:d}, Header:{1}", (short)Functions.Atoi( Functions.Left( HEADER , (int)( 1 ) ) ), HEADER ) ; 
                        __context__.SourceCodeLine = 54;
                        Functions.ClearBuffer ( CRPC_FROM_CLIENT ) ; 
                        } 
                    
                    }
                
                __context__.SourceCodeLine = 32;
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
public void MESSAGEFROMSERVER ( SimplSharpString MESSAGE ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
        
        __context__.SourceCodeLine = 61;
        CRPC_TO_CLIENT  .UpdateValue ( MESSAGE  .ToString()  ) ; 
        
        
    }
    finally { ObjectFinallyHandler(); }
    }
    
public void SERVERCONNECTEDSTATUSCHANGED ( ushort SERVERCONNECTED ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
        
        __context__.SourceCodeLine = 66;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SERVERCONNECTED == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 68;
            SERVER_OFFLINE  .Value = (ushort) ( 0 ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 70;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SERVERCONNECTED == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 72;
                SERVER_OFFLINE  .Value = (ushort) ( 1 ) ; 
                } 
            
            }
        
        
        
    }
    finally { ObjectFinallyHandler(); }
    }
    
public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 79;
        // RegisterDelegate( CRPCSERIALCLIENTCONNECTION , CLIENTTX , MESSAGEFROMSERVER ) 
        CRPCSERIALCLIENTCONNECTION .ClientTx  = MESSAGEFROMSERVER; ; 
        __context__.SourceCodeLine = 80;
        // RegisterDelegate( CRPCSERIALCLIENTCONNECTION , TRIGGERSERVERCONNECTED , SERVERCONNECTEDSTATUSCHANGED ) 
        CRPCSERIALCLIENTCONNECTION .TriggerServerConnected  = SERVERCONNECTEDSTATUSCHANGED; ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    CONNECT = new Crestron.Logos.SplusObjects.DigitalInput( CONNECT__DigitalInput__, this );
    m_DigitalInputList.Add( CONNECT__DigitalInput__, CONNECT );
    
    SERVER_OFFLINE = new Crestron.Logos.SplusObjects.DigitalOutput( SERVER_OFFLINE__DigitalOutput__, this );
    m_DigitalOutputList.Add( SERVER_OFFLINE__DigitalOutput__, SERVER_OFFLINE );
    
    CRPC_TO_CLIENT = new Crestron.Logos.SplusObjects.StringOutput( CRPC_TO_CLIENT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CRPC_TO_CLIENT__AnalogSerialOutput__, CRPC_TO_CLIENT );
    
    CRPC_FROM_CLIENT = new Crestron.Logos.SplusObjects.BufferInput( CRPC_FROM_CLIENT__AnalogSerialInput__, 65534, this );
    m_StringInputList.Add( CRPC_FROM_CLIENT__AnalogSerialInput__, CRPC_FROM_CLIENT );
    
    
    CONNECT.OnDigitalPush.Add( new InputChangeHandlerWrapper( CONNECT_OnPush_0, false ) );
    CRPC_FROM_CLIENT.OnSerialChange.Add( new InputChangeHandlerWrapper( CRPC_FROM_CLIENT_OnChange_1, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    CRPCSERIALCLIENTCONNECTION  = new AffinityClientConnection.Client.Serial_Client_Interface.SerialClientInterface();
    
    
}

public CrestronModuleClass_SERIAL_CLIENT_INTERFACE_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint CONNECT__DigitalInput__ = 0;
const uint CRPC_FROM_CLIENT__AnalogSerialInput__ = 0;
const uint SERVER_OFFLINE__DigitalOutput__ = 0;
const uint CRPC_TO_CLIENT__AnalogSerialOutput__ = 0;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
