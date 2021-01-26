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

namespace CrestronModule_MARANTZ_SR6003_SLEEP_TIMER_PROCESSOR_V1
{
    public class CrestronModuleClass_MARANTZ_SR6003_SLEEP_TIMER_PROCESSOR_V1 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.BufferInput FROMDEVICE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput SLEEP_OFFFB;
        Crestron.Logos.SplusObjects.DigitalOutput ROOMASLEEP_OFFFB;
        Crestron.Logos.SplusObjects.DigitalOutput ROOMBSLEEP_OFFFB;
        Crestron.Logos.SplusObjects.AnalogOutput SLEEP_LEVEL;
        Crestron.Logos.SplusObjects.AnalogOutput ROOMASLEEP_LEVEL;
        Crestron.Logos.SplusObjects.AnalogOutput ROOMBSLEEP_LEVEL;
        Crestron.Logos.SplusObjects.StringOutput SLEEP_TEXT;
        Crestron.Logos.SplusObjects.StringOutput ROOMASLEEP_TEXT;
        Crestron.Logos.SplusObjects.StringOutput ROOMBSLEEP_TEXT;
        private void SLEEPTIMER (  SplusExecutionContext __context__, CrestronString S ) 
            { 
            ushort X = 0;
            
            CrestronString TEMPSTRING;
            TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 15, this );
            
            CrestronString TRASH;
            TRASH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
            
            
            __context__.SourceCodeLine = 29;
            if ( Functions.TestForTrue  ( ( Functions.Find( "@SLP:000" , S ))  ) ) 
                { 
                __context__.SourceCodeLine = 31;
                TRASH  .UpdateValue ( Functions.Remove ( "@SLP:" , S )  ) ; 
                __context__.SourceCodeLine = 31;
                SLEEP_OFFFB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 31;
                X = (ushort) ( Functions.Atoi( S ) ) ; 
                __context__.SourceCodeLine = 31;
                SLEEP_LEVEL  .Value = (ushort) ( X ) ; 
                __context__.SourceCodeLine = 31;
                SLEEP_TEXT  .UpdateValue ( "--"  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 35;
                TRASH  .UpdateValue ( Functions.Remove ( "@SLP:" , S )  ) ; 
                __context__.SourceCodeLine = 35;
                SLEEP_OFFFB  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 35;
                X = (ushort) ( Functions.Atoi( S ) ) ; 
                __context__.SourceCodeLine = 36;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( X <= 9 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 36;
                    MakeString ( TEMPSTRING , "0{0:d} Min", (short)X) ; 
                    __context__.SourceCodeLine = 36;
                    SLEEP_LEVEL  .Value = (ushort) ( X ) ; 
                    __context__.SourceCodeLine = 36;
                    SLEEP_TEXT  .UpdateValue ( TEMPSTRING  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 37;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( X >= 10 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 37;
                        MakeString ( TEMPSTRING , "{0:d} Min", (short)X) ; 
                        __context__.SourceCodeLine = 37;
                        SLEEP_LEVEL  .Value = (ushort) ( X ) ; 
                        __context__.SourceCodeLine = 37;
                        SLEEP_TEXT  .UpdateValue ( TEMPSTRING  ) ; 
                        } 
                    
                    }
                
                } 
            
            
            }
            
        private void ROOMASLEEPTIMER (  SplusExecutionContext __context__, CrestronString S ) 
            { 
            ushort X = 0;
            
            CrestronString TEMPSTRING;
            TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 15, this );
            
            CrestronString TRASH;
            TRASH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
            
            
            __context__.SourceCodeLine = 47;
            if ( Functions.TestForTrue  ( ( Functions.Find( "@MSL:000" , S ))  ) ) 
                { 
                __context__.SourceCodeLine = 49;
                TRASH  .UpdateValue ( Functions.Remove ( "@MSL:" , S )  ) ; 
                __context__.SourceCodeLine = 49;
                ROOMASLEEP_OFFFB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 49;
                X = (ushort) ( Functions.Atoi( S ) ) ; 
                __context__.SourceCodeLine = 49;
                ROOMASLEEP_LEVEL  .Value = (ushort) ( X ) ; 
                __context__.SourceCodeLine = 49;
                ROOMASLEEP_TEXT  .UpdateValue ( "--"  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 53;
                TRASH  .UpdateValue ( Functions.Remove ( "@MSL:" , S )  ) ; 
                __context__.SourceCodeLine = 53;
                ROOMASLEEP_OFFFB  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 53;
                X = (ushort) ( Functions.Atoi( S ) ) ; 
                __context__.SourceCodeLine = 54;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( X <= 9 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 54;
                    MakeString ( TEMPSTRING , "0{0:d} Min", (short)X) ; 
                    __context__.SourceCodeLine = 54;
                    ROOMASLEEP_LEVEL  .Value = (ushort) ( X ) ; 
                    __context__.SourceCodeLine = 54;
                    ROOMASLEEP_TEXT  .UpdateValue ( TEMPSTRING  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 55;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( X >= 10 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 55;
                        MakeString ( TEMPSTRING , "{0:d} Min", (short)X) ; 
                        __context__.SourceCodeLine = 55;
                        ROOMASLEEP_LEVEL  .Value = (ushort) ( X ) ; 
                        __context__.SourceCodeLine = 55;
                        ROOMASLEEP_TEXT  .UpdateValue ( TEMPSTRING  ) ; 
                        } 
                    
                    }
                
                } 
            
            
            }
            
        private void ROOMBSLEEPTIMER (  SplusExecutionContext __context__, CrestronString S ) 
            { 
            ushort X = 0;
            
            CrestronString TEMPSTRING;
            TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 15, this );
            
            CrestronString TRASH;
            TRASH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
            
            
            __context__.SourceCodeLine = 66;
            if ( Functions.TestForTrue  ( ( Functions.Find( "@MSL=000" , S ))  ) ) 
                { 
                __context__.SourceCodeLine = 68;
                TRASH  .UpdateValue ( Functions.Remove ( "@MSL=" , S )  ) ; 
                __context__.SourceCodeLine = 68;
                ROOMBSLEEP_OFFFB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 68;
                X = (ushort) ( Functions.Atoi( S ) ) ; 
                __context__.SourceCodeLine = 68;
                ROOMBSLEEP_LEVEL  .Value = (ushort) ( X ) ; 
                __context__.SourceCodeLine = 68;
                ROOMBSLEEP_TEXT  .UpdateValue ( "--"  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 72;
                TRASH  .UpdateValue ( Functions.Remove ( "@MSL=" , S )  ) ; 
                __context__.SourceCodeLine = 72;
                ROOMBSLEEP_OFFFB  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 72;
                X = (ushort) ( Functions.Atoi( S ) ) ; 
                __context__.SourceCodeLine = 73;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( X <= 9 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 73;
                    MakeString ( TEMPSTRING , "0{0:d} Min", (short)X) ; 
                    __context__.SourceCodeLine = 73;
                    ROOMBSLEEP_LEVEL  .Value = (ushort) ( X ) ; 
                    __context__.SourceCodeLine = 73;
                    ROOMBSLEEP_TEXT  .UpdateValue ( TEMPSTRING  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 74;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( X >= 10 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 74;
                        MakeString ( TEMPSTRING , "{0:d} Min", (short)X) ; 
                        __context__.SourceCodeLine = 74;
                        ROOMBSLEEP_LEVEL  .Value = (ushort) ( X ) ; 
                        __context__.SourceCodeLine = 74;
                        ROOMBSLEEP_TEXT  .UpdateValue ( TEMPSTRING  ) ; 
                        } 
                    
                    }
                
                } 
            
            
            }
            
        object FROMDEVICE__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 82;
                while ( Functions.TestForTrue  ( ( Functions.Find( "\u000D" , FROMDEVICE__DOLLAR__ ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 84;
                    _SplusNVRAM.G_STEMPSTRING__DOLLAR__  .UpdateValue ( Functions.Gather ( "\u000D" , FROMDEVICE__DOLLAR__ )  ) ; 
                    __context__.SourceCodeLine = 86;
                    if ( Functions.TestForTrue  ( ( Functions.Find( "@SLP:" , _SplusNVRAM.G_STEMPSTRING__DOLLAR__ ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 88;
                        SLEEPTIMER (  __context__ , _SplusNVRAM.G_STEMPSTRING__DOLLAR__) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 90;
                        if ( Functions.TestForTrue  ( ( Functions.Find( "@MSL:" , _SplusNVRAM.G_STEMPSTRING__DOLLAR__ ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 92;
                            ROOMASLEEPTIMER (  __context__ , _SplusNVRAM.G_STEMPSTRING__DOLLAR__) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 94;
                            if ( Functions.TestForTrue  ( ( Functions.Find( "@MSL=" , _SplusNVRAM.G_STEMPSTRING__DOLLAR__ ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 96;
                                ROOMBSLEEPTIMER (  __context__ , _SplusNVRAM.G_STEMPSTRING__DOLLAR__) ; 
                                } 
                            
                            }
                        
                        }
                    
                    __context__.SourceCodeLine = 82;
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        _SplusNVRAM.G_STEMPSTRING__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
        
        SLEEP_OFFFB = new Crestron.Logos.SplusObjects.DigitalOutput( SLEEP_OFFFB__DigitalOutput__, this );
        m_DigitalOutputList.Add( SLEEP_OFFFB__DigitalOutput__, SLEEP_OFFFB );
        
        ROOMASLEEP_OFFFB = new Crestron.Logos.SplusObjects.DigitalOutput( ROOMASLEEP_OFFFB__DigitalOutput__, this );
        m_DigitalOutputList.Add( ROOMASLEEP_OFFFB__DigitalOutput__, ROOMASLEEP_OFFFB );
        
        ROOMBSLEEP_OFFFB = new Crestron.Logos.SplusObjects.DigitalOutput( ROOMBSLEEP_OFFFB__DigitalOutput__, this );
        m_DigitalOutputList.Add( ROOMBSLEEP_OFFFB__DigitalOutput__, ROOMBSLEEP_OFFFB );
        
        SLEEP_LEVEL = new Crestron.Logos.SplusObjects.AnalogOutput( SLEEP_LEVEL__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( SLEEP_LEVEL__AnalogSerialOutput__, SLEEP_LEVEL );
        
        ROOMASLEEP_LEVEL = new Crestron.Logos.SplusObjects.AnalogOutput( ROOMASLEEP_LEVEL__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( ROOMASLEEP_LEVEL__AnalogSerialOutput__, ROOMASLEEP_LEVEL );
        
        ROOMBSLEEP_LEVEL = new Crestron.Logos.SplusObjects.AnalogOutput( ROOMBSLEEP_LEVEL__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( ROOMBSLEEP_LEVEL__AnalogSerialOutput__, ROOMBSLEEP_LEVEL );
        
        SLEEP_TEXT = new Crestron.Logos.SplusObjects.StringOutput( SLEEP_TEXT__AnalogSerialOutput__, this );
        m_StringOutputList.Add( SLEEP_TEXT__AnalogSerialOutput__, SLEEP_TEXT );
        
        ROOMASLEEP_TEXT = new Crestron.Logos.SplusObjects.StringOutput( ROOMASLEEP_TEXT__AnalogSerialOutput__, this );
        m_StringOutputList.Add( ROOMASLEEP_TEXT__AnalogSerialOutput__, ROOMASLEEP_TEXT );
        
        ROOMBSLEEP_TEXT = new Crestron.Logos.SplusObjects.StringOutput( ROOMBSLEEP_TEXT__AnalogSerialOutput__, this );
        m_StringOutputList.Add( ROOMBSLEEP_TEXT__AnalogSerialOutput__, ROOMBSLEEP_TEXT );
        
        FROMDEVICE__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( FROMDEVICE__DOLLAR____AnalogSerialInput__, 500, this );
        m_StringInputList.Add( FROMDEVICE__DOLLAR____AnalogSerialInput__, FROMDEVICE__DOLLAR__ );
        
        
        FROMDEVICE__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( FROMDEVICE__DOLLAR___OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public CrestronModuleClass_MARANTZ_SR6003_SLEEP_TIMER_PROCESSOR_V1 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint FROMDEVICE__DOLLAR____AnalogSerialInput__ = 0;
    const uint SLEEP_OFFFB__DigitalOutput__ = 0;
    const uint ROOMASLEEP_OFFFB__DigitalOutput__ = 1;
    const uint ROOMBSLEEP_OFFFB__DigitalOutput__ = 2;
    const uint SLEEP_LEVEL__AnalogSerialOutput__ = 0;
    const uint ROOMASLEEP_LEVEL__AnalogSerialOutput__ = 1;
    const uint ROOMBSLEEP_LEVEL__AnalogSerialOutput__ = 2;
    const uint SLEEP_TEXT__AnalogSerialOutput__ = 3;
    const uint ROOMASLEEP_TEXT__AnalogSerialOutput__ = 4;
    const uint ROOMBSLEEP_TEXT__AnalogSerialOutput__ = 5;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        [SplusStructAttribute(0, false, true)]
            public CrestronString G_STEMPSTRING__DOLLAR__;
            
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
