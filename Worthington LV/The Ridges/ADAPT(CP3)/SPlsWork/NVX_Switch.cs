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

namespace UserModule_NVX_SWITCH
{
    public class UserModuleClass_NVX_SWITCH : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        Crestron.Logos.SplusObjects.AnalogInput INDEX;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> SOURCE;
        Crestron.Logos.SplusObjects.StringOutput OUTPUT;
        object INDEX_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 178;
                OUTPUT  .UpdateValue ( SOURCE [ INDEX  .UshortValue ]  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        INDEX = new Crestron.Logos.SplusObjects.AnalogInput( INDEX__AnalogSerialInput__, this );
        m_AnalogInputList.Add( INDEX__AnalogSerialInput__, INDEX );
        
        SOURCE = new InOutArray<StringInput>( 10, this );
        for( uint i = 0; i < 10; i++ )
        {
            SOURCE[i+1] = new Crestron.Logos.SplusObjects.StringInput( SOURCE__AnalogSerialInput__ + i, SOURCE__AnalogSerialInput__, 50, this );
            m_StringInputList.Add( SOURCE__AnalogSerialInput__ + i, SOURCE[i+1] );
        }
        
        OUTPUT = new Crestron.Logos.SplusObjects.StringOutput( OUTPUT__AnalogSerialOutput__, this );
        m_StringOutputList.Add( OUTPUT__AnalogSerialOutput__, OUTPUT );
        
        
        INDEX.OnAnalogChange.Add( new InputChangeHandlerWrapper( INDEX_OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_NVX_SWITCH ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint INDEX__AnalogSerialInput__ = 0;
    const uint SOURCE__AnalogSerialInput__ = 1;
    const uint OUTPUT__AnalogSerialOutput__ = 0;
    
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
