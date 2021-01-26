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
using SonosLibrary_v3_0.SimplPlusInterfaces;
using SonosProLibrary_v3_0.DataStructures;
using SonosProLibrary_v3_0.Diagnostics.Impl;
using SonosProLibrary_v3_0.Devices.Events;
using SonosProLibrary_v3_0.System.Enums;
using SonosProLibrary_v3_0.System.Events;
using SonosLibrary_v3_0.SimplPlusInterfaces.Events;
using SonosProLibrary_v3_0.System;
using SonosProLibrary_v3_0.Diagnostics.Events;
using SonosProLibrary_v3_0.Diagnostics.Enums;
using SonosProLibrary_v3_0.Logging.Enums;
using SonosProLibrary_v3_0.Diagnostics;
using SonosProLibrary_v3_0.API;
using SonosProLibrary_v3_0.Devices;
using Crestron.AppHelperClassesv2_0;
using AppHelperClasses;
using Crestron.AppHelperClasses;
using Crestron.CRPC.CIPDirectTransport;
using Crestron.CRPC;
using Crestron.CRPC.Common;
using CRPCConnectionHelper;
using Crestron.CRPC.MediaPlayer;

namespace CrestronModule_SONOS_SYSTEM_ENGINE_V3_0_0
{
    public class CrestronModuleClass_SONOS_SYSTEM_ENGINE_V3_0_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZE;
        Crestron.Logos.SplusObjects.DigitalInput DISCOVERGROUPS;
        Crestron.Logos.SplusObjects.DigitalInput STOPDISCOVERY;
        Crestron.Logos.SplusObjects.DigitalInput GETFAVORITES;
        Crestron.Logos.SplusObjects.DigitalInput ENABLEDEBUGMODE;
        Crestron.Logos.SplusObjects.DigitalInput DISABLEDEBUGMODE;
        Crestron.Logos.SplusObjects.DigitalOutput BUSY_FB;
        Crestron.Logos.SplusObjects.DigitalOutput DISCOVERINGGROUPS_FB;
        Crestron.Logos.SplusObjects.DigitalOutput GETTINGFAVORITES_FB;
        SonosLibrary_v3_0.SimplPlusInterfaces.SystemSimplPlusInterface SYSTEMINTERFACE;
        private void REGISTERDELEGATES (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 89;
            // RegisterDelegate( SYSTEMINTERFACE , PLAYERBUSYUPDATE , UPDATEBUSYSTATUS ) 
            SYSTEMINTERFACE .PlayerBusyUpdate  = UPDATEBUSYSTATUS; ; 
            
            }
            
        public void UPDATEBUSYSTATUS ( ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 94;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SYSTEMINTERFACE.BusyStatus == "true"))  ) ) 
                    {
                    __context__.SourceCodeLine = 95;
                    BUSY_FB  .Value = (ushort) ( 1 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 97;
                    BUSY_FB  .Value = (ushort) ( 0 ) ; 
                    }
                
                __context__.SourceCodeLine = 99;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SYSTEMINTERFACE.DiscoveringGroups == "true"))  ) ) 
                    {
                    __context__.SourceCodeLine = 100;
                    DISCOVERINGGROUPS_FB  .Value = (ushort) ( 1 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 102;
                    DISCOVERINGGROUPS_FB  .Value = (ushort) ( 0 ) ; 
                    }
                
                __context__.SourceCodeLine = 104;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SYSTEMINTERFACE.GettingFavorites == "true"))  ) ) 
                    {
                    __context__.SourceCodeLine = 105;
                    GETTINGFAVORITES_FB  .Value = (ushort) ( 1 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 107;
                    GETTINGFAVORITES_FB  .Value = (ushort) ( 0 ) ; 
                    }
                
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object INITIALIZE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 120;
                SYSTEMINTERFACE . Initialize ( ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object DISCOVERGROUPS_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 125;
            SYSTEMINTERFACE . DiscoverGroups ( ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object STOPDISCOVERY_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 130;
        SYSTEMINTERFACE . StopDiscovery ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object GETFAVORITES_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 136;
        SYSTEMINTERFACE . GetFavorites ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENABLEDEBUGMODE_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 141;
        SYSTEMINTERFACE . EnableLogger ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DISABLEDEBUGMODE_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 146;
        SYSTEMINTERFACE . DisableLogger ( ) ; 
        
        
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
        
        __context__.SourceCodeLine = 158;
        REGISTERDELEGATES (  __context__  ) ; 
        __context__.SourceCodeLine = 159;
        WaitForInitializationComplete ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    INITIALIZE = new Crestron.Logos.SplusObjects.DigitalInput( INITIALIZE__DigitalInput__, this );
    m_DigitalInputList.Add( INITIALIZE__DigitalInput__, INITIALIZE );
    
    DISCOVERGROUPS = new Crestron.Logos.SplusObjects.DigitalInput( DISCOVERGROUPS__DigitalInput__, this );
    m_DigitalInputList.Add( DISCOVERGROUPS__DigitalInput__, DISCOVERGROUPS );
    
    STOPDISCOVERY = new Crestron.Logos.SplusObjects.DigitalInput( STOPDISCOVERY__DigitalInput__, this );
    m_DigitalInputList.Add( STOPDISCOVERY__DigitalInput__, STOPDISCOVERY );
    
    GETFAVORITES = new Crestron.Logos.SplusObjects.DigitalInput( GETFAVORITES__DigitalInput__, this );
    m_DigitalInputList.Add( GETFAVORITES__DigitalInput__, GETFAVORITES );
    
    ENABLEDEBUGMODE = new Crestron.Logos.SplusObjects.DigitalInput( ENABLEDEBUGMODE__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLEDEBUGMODE__DigitalInput__, ENABLEDEBUGMODE );
    
    DISABLEDEBUGMODE = new Crestron.Logos.SplusObjects.DigitalInput( DISABLEDEBUGMODE__DigitalInput__, this );
    m_DigitalInputList.Add( DISABLEDEBUGMODE__DigitalInput__, DISABLEDEBUGMODE );
    
    BUSY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( BUSY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( BUSY_FB__DigitalOutput__, BUSY_FB );
    
    DISCOVERINGGROUPS_FB = new Crestron.Logos.SplusObjects.DigitalOutput( DISCOVERINGGROUPS_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( DISCOVERINGGROUPS_FB__DigitalOutput__, DISCOVERINGGROUPS_FB );
    
    GETTINGFAVORITES_FB = new Crestron.Logos.SplusObjects.DigitalOutput( GETTINGFAVORITES_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( GETTINGFAVORITES_FB__DigitalOutput__, GETTINGFAVORITES_FB );
    
    
    INITIALIZE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZE_OnPush_0, false ) );
    DISCOVERGROUPS.OnDigitalPush.Add( new InputChangeHandlerWrapper( DISCOVERGROUPS_OnPush_1, false ) );
    STOPDISCOVERY.OnDigitalPush.Add( new InputChangeHandlerWrapper( STOPDISCOVERY_OnPush_2, false ) );
    GETFAVORITES.OnDigitalPush.Add( new InputChangeHandlerWrapper( GETFAVORITES_OnPush_3, false ) );
    ENABLEDEBUGMODE.OnDigitalPush.Add( new InputChangeHandlerWrapper( ENABLEDEBUGMODE_OnPush_4, false ) );
    DISABLEDEBUGMODE.OnDigitalPush.Add( new InputChangeHandlerWrapper( DISABLEDEBUGMODE_OnPush_5, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    SYSTEMINTERFACE  = new SonosLibrary_v3_0.SimplPlusInterfaces.SystemSimplPlusInterface();
    
    
}

public CrestronModuleClass_SONOS_SYSTEM_ENGINE_V3_0_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INITIALIZE__DigitalInput__ = 0;
const uint DISCOVERGROUPS__DigitalInput__ = 1;
const uint STOPDISCOVERY__DigitalInput__ = 2;
const uint GETFAVORITES__DigitalInput__ = 3;
const uint ENABLEDEBUGMODE__DigitalInput__ = 4;
const uint DISABLEDEBUGMODE__DigitalInput__ = 5;
const uint BUSY_FB__DigitalOutput__ = 0;
const uint DISCOVERINGGROUPS_FB__DigitalOutput__ = 1;
const uint GETTINGFAVORITES_FB__DigitalOutput__ = 2;

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
