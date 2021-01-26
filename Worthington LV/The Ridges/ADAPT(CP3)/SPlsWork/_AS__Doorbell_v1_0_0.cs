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
using UserModule__AS__CONSTANTS;
using AdaptCore;
using AdaptCore.Core;

namespace UserModule__AS__DOORBELL_V1_0_0
{
    public class UserModuleClass__AS__DOORBELL_V1_0_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        Crestron.Logos.SplusObjects.DigitalInput INIT;
        Crestron.Logos.SplusObjects.DigitalInput DOORBELLTRIGGER;
        Crestron.Logos.SplusObjects.DigitalInput CANCEL;
        Crestron.Logos.SplusObjects.DigitalOutput PLAYCHIMEPULSE;
        UShortParameter DOORBELL_NUMBER;
        StringParameter DOORBELL_NAME;
        UShortParameter ACCESS_LEVEL;
        StringParameter FILE_NAME__DOLLAR__;
        StringParameter READ_AT_BOOTUP;
        UShortParameter SOURCE_NUMBER;
        StringParameter EVENTMESSAGE;
        UShortParameter DURATION;
        UShortParameter CHIME_DELAY;
        AdaptCore.PD_Doorbell MYBRIDGE;
        public void HANDLEDOORBELLPLAYCHIME ( object __sender__ /*AdaptCore.PD_Bridge SENDER */, AdaptCore.PD_ValueEventArgs ARGS ) 
            { 
            PD_Bridge  SENDER  = (PD_Bridge )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 39;
                Functions.Pulse ( 1, PLAYCHIMEPULSE ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object INIT_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 44;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (GetSymbolReferenceName() == "DEBUG"))  ) ) 
                    {
                    __context__.SourceCodeLine = 44;
                    MYBRIDGE . DebugOn = (ushort) ( 1 ) ; 
                    }
                
                __context__.SourceCodeLine = 45;
                MYBRIDGE . SymbolName  =  ( "P" + Functions.ItoA (  (int) ( GetProgramNumber() ) ) + ":" + GetSymbolInstanceName ( )  )  .ToString() ; 
                __context__.SourceCodeLine = 46;
                MYBRIDGE . FriendlyId = (ushort) ( DOORBELL_NUMBER  .Value ) ; 
                __context__.SourceCodeLine = 47;
                MYBRIDGE . FriendlyName  =  ( DOORBELL_NAME + Functions.ItoA (  (int) ( DOORBELL_NUMBER  .Value ) )  )  .ToString() ; 
                __context__.SourceCodeLine = 48;
                MYBRIDGE . AccessLevel = (ushort) ( ACCESS_LEVEL  .Value ) ; 
                __context__.SourceCodeLine = 49;
                MYBRIDGE . ReadAtBootup  =  ( READ_AT_BOOTUP  )  .ToString() ; 
                __context__.SourceCodeLine = 50;
                MYBRIDGE . SourceNum = (ushort) ( SOURCE_NUMBER  .Value ) ; 
                __context__.SourceCodeLine = 51;
                MYBRIDGE . Message  =  ( EVENTMESSAGE  )  .ToString() ; 
                __context__.SourceCodeLine = 52;
                MYBRIDGE . Duration = (ushort) ( DURATION  .Value ) ; 
                __context__.SourceCodeLine = 53;
                MYBRIDGE . ChimeDelay = (int) ( CHIME_DELAY  .Value ) ; 
                __context__.SourceCodeLine = 55;
                // RegisterEvent( MYBRIDGE , SETDOORBELLPLAYCHIME , HANDLEDOORBELLPLAYCHIME ) 
                try { g_criticalSection.Enter(); MYBRIDGE .SetDoorbellPlayChime  += HANDLEDOORBELLPLAYCHIME; } finally { g_criticalSection.Leave(); }
                ; 
                __context__.SourceCodeLine = 57;
                MYBRIDGE . RegisterWithCore ( ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object DOORBELLTRIGGER_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 61;
            MYBRIDGE . TriggerDoorbell ( ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object CANCEL_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 62;
        MYBRIDGE . CancelDoorbell ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}


public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    INIT = new Crestron.Logos.SplusObjects.DigitalInput( INIT__DigitalInput__, this );
    m_DigitalInputList.Add( INIT__DigitalInput__, INIT );
    
    DOORBELLTRIGGER = new Crestron.Logos.SplusObjects.DigitalInput( DOORBELLTRIGGER__DigitalInput__, this );
    m_DigitalInputList.Add( DOORBELLTRIGGER__DigitalInput__, DOORBELLTRIGGER );
    
    CANCEL = new Crestron.Logos.SplusObjects.DigitalInput( CANCEL__DigitalInput__, this );
    m_DigitalInputList.Add( CANCEL__DigitalInput__, CANCEL );
    
    PLAYCHIMEPULSE = new Crestron.Logos.SplusObjects.DigitalOutput( PLAYCHIMEPULSE__DigitalOutput__, this );
    m_DigitalOutputList.Add( PLAYCHIMEPULSE__DigitalOutput__, PLAYCHIMEPULSE );
    
    DOORBELL_NUMBER = new UShortParameter( DOORBELL_NUMBER__Parameter__, this );
    m_ParameterList.Add( DOORBELL_NUMBER__Parameter__, DOORBELL_NUMBER );
    
    ACCESS_LEVEL = new UShortParameter( ACCESS_LEVEL__Parameter__, this );
    m_ParameterList.Add( ACCESS_LEVEL__Parameter__, ACCESS_LEVEL );
    
    SOURCE_NUMBER = new UShortParameter( SOURCE_NUMBER__Parameter__, this );
    m_ParameterList.Add( SOURCE_NUMBER__Parameter__, SOURCE_NUMBER );
    
    DURATION = new UShortParameter( DURATION__Parameter__, this );
    m_ParameterList.Add( DURATION__Parameter__, DURATION );
    
    CHIME_DELAY = new UShortParameter( CHIME_DELAY__Parameter__, this );
    m_ParameterList.Add( CHIME_DELAY__Parameter__, CHIME_DELAY );
    
    DOORBELL_NAME = new StringParameter( DOORBELL_NAME__Parameter__, this );
    m_ParameterList.Add( DOORBELL_NAME__Parameter__, DOORBELL_NAME );
    
    FILE_NAME__DOLLAR__ = new StringParameter( FILE_NAME__DOLLAR____Parameter__, this );
    m_ParameterList.Add( FILE_NAME__DOLLAR____Parameter__, FILE_NAME__DOLLAR__ );
    
    READ_AT_BOOTUP = new StringParameter( READ_AT_BOOTUP__Parameter__, this );
    m_ParameterList.Add( READ_AT_BOOTUP__Parameter__, READ_AT_BOOTUP );
    
    EVENTMESSAGE = new StringParameter( EVENTMESSAGE__Parameter__, this );
    m_ParameterList.Add( EVENTMESSAGE__Parameter__, EVENTMESSAGE );
    
    
    INIT.OnDigitalPush.Add( new InputChangeHandlerWrapper( INIT_OnPush_0, true ) );
    DOORBELLTRIGGER.OnDigitalPush.Add( new InputChangeHandlerWrapper( DOORBELLTRIGGER_OnPush_1, false ) );
    CANCEL.OnDigitalPush.Add( new InputChangeHandlerWrapper( CANCEL_OnPush_2, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    MYBRIDGE  = new AdaptCore.PD_Doorbell();
    
    
}

public UserModuleClass__AS__DOORBELL_V1_0_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INIT__DigitalInput__ = 0;
const uint DOORBELLTRIGGER__DigitalInput__ = 1;
const uint CANCEL__DigitalInput__ = 2;
const uint PLAYCHIMEPULSE__DigitalOutput__ = 0;
const uint DOORBELL_NUMBER__Parameter__ = 10;
const uint DOORBELL_NAME__Parameter__ = 11;
const uint ACCESS_LEVEL__Parameter__ = 12;
const uint FILE_NAME__DOLLAR____Parameter__ = 13;
const uint READ_AT_BOOTUP__Parameter__ = 14;
const uint SOURCE_NUMBER__Parameter__ = 15;
const uint EVENTMESSAGE__Parameter__ = 16;
const uint DURATION__Parameter__ = 17;
const uint CHIME_DELAY__Parameter__ = 18;

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
