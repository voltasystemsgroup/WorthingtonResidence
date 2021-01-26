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

namespace UserModule_SONY_2014_BRAVIA_TV_CHANNEL_DRIVER_V1_0
{
    public class UserModuleClass_SONY_2014_BRAVIA_TV_CHANNEL_DRIVER_V1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput SELECT_TV_INPUT;
        Crestron.Logos.SplusObjects.BufferInput FROM_DEVICE;
        Crestron.Logos.SplusObjects.StringOutput CURRENT_CHANNEL_TEXT;
        Crestron.Logos.SplusObjects.StringOutput TO_DEVICE;
        ushort IFLAG1 = 0;
        CrestronString SCHANNEL;
        private void FPROCESSDATA (  SplusExecutionContext __context__, CrestronString FSTEMP ) 
            { 
            ushort FITEMPCHANNELHIGH = 0;
            ushort FITEMPCHANNELLOW = 0;
            ushort FIMARKER1 = 0;
            
            
            __context__.SourceCodeLine = 64;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (FSTEMP == "*SACHNNFFFFFFFFFFFFFFFF\u000A") ) || Functions.TestForTrue ( Functions.BoolToInt (FSTEMP == "*SACHNNNNNNNNNNNNNNNNNN\u000A") )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (FSTEMP == "*SCCHNNFFFFFFFFFFFFFFFF\u000A") )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (FSTEMP == "*SCCHNNNNNNNNNNNNNNNNNN\u000A") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 67;
                FSTEMP  .UpdateValue ( ""  ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 69;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Left( FSTEMP , (int)( Functions.Length( "*SACHNN" ) ) ) == "*SACHNN") ) || Functions.TestForTrue ( Functions.BoolToInt (Functions.Left( FSTEMP , (int)( Functions.Length( "*SNCHNN" ) ) ) == "*SNCHNN") )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 71;
                    FIMARKER1 = (ushort) ( Functions.Find( "." , FSTEMP ) ) ; 
                    __context__.SourceCodeLine = 72;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIMARKER1 > 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 74;
                        FITEMPCHANNELHIGH = (ushort) ( Functions.Atoi( FSTEMP ) ) ; 
                        __context__.SourceCodeLine = 75;
                        MakeString ( SCHANNEL , "{0:d}.{1}", (short)FITEMPCHANNELHIGH, Functions.Mid ( FSTEMP ,  (int) ( (FIMARKER1 + 1) ) ,  (int) ( (Functions.Length( FSTEMP ) - (FIMARKER1 + 1)) ) ) ) ; 
                        __context__.SourceCodeLine = 76;
                        while ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Right( SCHANNEL , (int)( 1 ) ) == "0"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 78;
                            SCHANNEL  .UpdateValue ( Functions.Left ( SCHANNEL ,  (int) ( (Functions.Length( SCHANNEL ) - 1) ) )  ) ; 
                            __context__.SourceCodeLine = 76;
                            } 
                        
                        __context__.SourceCodeLine = 80;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Right( SCHANNEL , (int)( 1 ) ) == "."))  ) ) 
                            { 
                            __context__.SourceCodeLine = 82;
                            SCHANNEL  .UpdateValue ( SCHANNEL + "0"  ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 84;
                        CURRENT_CHANNEL_TEXT  .UpdateValue ( SCHANNEL  ) ; 
                        } 
                    
                    } 
                
                }
            
            
            }
            
        private CrestronString SFSENDTVINPUTCOMMAND (  SplusExecutionContext __context__, CrestronString FSCHANNEL ) 
            { 
            CrestronString FSRETURN;
            FSRETURN  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
            
            ushort FIMARKER1 = 0;
            
            
            __context__.SourceCodeLine = 94;
            FIMARKER1 = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 95;
            FIMARKER1 = (ushort) ( Functions.Find( "." , FSCHANNEL ) ) ; 
            __context__.SourceCodeLine = 96;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FIMARKER1 == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 98;
                MakeString ( FSRETURN , "*SCCHNN{0:d8}.0000000\u000A", (short)Functions.Atoi( FSCHANNEL )) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 100;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FIMARKER1 == Functions.Length( FSCHANNEL )))  ) ) 
                    { 
                    __context__.SourceCodeLine = 102;
                    MakeString ( FSRETURN , "*SCCHNN{0:d8}.0000000\u000A", (short)Functions.Atoi( FSCHANNEL )) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 106;
                    MakeString ( FSRETURN , "*SCCHNN{0:d8}.{1}", (short)Functions.Atoi( FSCHANNEL ), Functions.Right ( FSCHANNEL ,  (int) ( (Functions.Length( FSCHANNEL ) - FIMARKER1) ) ) ) ; 
                    __context__.SourceCodeLine = 107;
                    while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( FSRETURN ) < 23 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 109;
                        FSRETURN  .UpdateValue ( FSRETURN + "0"  ) ; 
                        __context__.SourceCodeLine = 107;
                        } 
                    
                    __context__.SourceCodeLine = 111;
                    FSRETURN  .UpdateValue ( FSRETURN + "\u000A"  ) ; 
                    } 
                
                }
            
            __context__.SourceCodeLine = 113;
            return ( FSRETURN ) ; 
            
            }
            
        object SELECT_TV_INPUT_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 121;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SCHANNEL ) > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 123;
                    TO_DEVICE  .UpdateValue ( SFSENDTVINPUTCOMMAND (  __context__ , SCHANNEL)  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 127;
                    TO_DEVICE  .UpdateValue ( SFSENDTVINPUTCOMMAND (  __context__ , "3")  ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object FROM_DEVICE_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            CrestronString ESTEMP;
            ESTEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            
            __context__.SourceCodeLine = 134;
            while ( Functions.TestForTrue  ( ( 1)  ) ) 
                { 
                __context__.SourceCodeLine = 136;
                ESTEMP  .UpdateValue ( Functions.Gather ( "\u000A" , FROM_DEVICE )  ) ; 
                __context__.SourceCodeLine = 137;
                FPROCESSDATA (  __context__ , ESTEMP) ; 
                __context__.SourceCodeLine = 134;
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 163;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 164;
        SCHANNEL  .UpdateValue ( "3"  ) ; 
        __context__.SourceCodeLine = 165;
        IFLAG1 = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    SCHANNEL  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
    
    SELECT_TV_INPUT = new Crestron.Logos.SplusObjects.DigitalInput( SELECT_TV_INPUT__DigitalInput__, this );
    m_DigitalInputList.Add( SELECT_TV_INPUT__DigitalInput__, SELECT_TV_INPUT );
    
    CURRENT_CHANNEL_TEXT = new Crestron.Logos.SplusObjects.StringOutput( CURRENT_CHANNEL_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CURRENT_CHANNEL_TEXT__AnalogSerialOutput__, CURRENT_CHANNEL_TEXT );
    
    TO_DEVICE = new Crestron.Logos.SplusObjects.StringOutput( TO_DEVICE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TO_DEVICE__AnalogSerialOutput__, TO_DEVICE );
    
    FROM_DEVICE = new Crestron.Logos.SplusObjects.BufferInput( FROM_DEVICE__AnalogSerialInput__, 250, this );
    m_StringInputList.Add( FROM_DEVICE__AnalogSerialInput__, FROM_DEVICE );
    
    
    SELECT_TV_INPUT.OnDigitalPush.Add( new InputChangeHandlerWrapper( SELECT_TV_INPUT_OnPush_0, false ) );
    FROM_DEVICE.OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_DEVICE_OnChange_1, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_SONY_2014_BRAVIA_TV_CHANNEL_DRIVER_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint SELECT_TV_INPUT__DigitalInput__ = 0;
const uint FROM_DEVICE__AnalogSerialInput__ = 0;
const uint CURRENT_CHANNEL_TEXT__AnalogSerialOutput__ = 0;
const uint TO_DEVICE__AnalogSerialOutput__ = 1;

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
