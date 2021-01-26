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

namespace UserModule_SONY_XBR_84X900_V1_0_PROCESSOR
{
    public class UserModuleClass_SONY_XBR_84X900_V1_0_PROCESSOR : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput SEND_STRING;
        Crestron.Logos.SplusObjects.DigitalInput FROM_DEVICE_PUSH;
        Crestron.Logos.SplusObjects.DigitalInput COMMAND_IN_PUSH;
        Crestron.Logos.SplusObjects.DigitalInput AIR;
        Crestron.Logos.SplusObjects.DigitalInput CABLE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> KP;
        Crestron.Logos.SplusObjects.StringInput COMMAND_IN;
        Crestron.Logos.SplusObjects.StringInput FROM_DEVICE;
        Crestron.Logos.SplusObjects.DigitalOutput SEQUENCE_ACTIVE;
        Crestron.Logos.SplusObjects.AnalogOutput TUNER_BAND_VALUE;
        Crestron.Logos.SplusObjects.StringOutput TO_DEVICE;
        Crestron.Logos.SplusObjects.StringOutput STATUS_STRING;
        Crestron.Logos.SplusObjects.StringOutput NUMBER_TEXT;
        ushort A = 0;
        ushort B = 0;
        ushort C = 0;
        ushort D = 0;
        ushort IFUNCTION = 0;
        ushort IDATA = 0;
        ushort ISTATE = 0;
        ushort [] ICOMMANDQUEUE;
        ushort IFUNCTIONACTIVE = 0;
        ushort ICOMMANDQUEUEFOUND = 0;
        ushort ICOMMANDQUEUEFOUND2 = 0;
        ushort ICURRENTCOMMAND = 0;
        ushort IFEEDBACKFAIL = 0;
        ushort ILOC = 0;
        ushort ITUNERBAND = 0;
        CrestronString SCOMMANDTOSEND;
        CrestronString [] SDATAREQUEST;
        CrestronString SCOMMANDTEMP;
        CrestronString SRESPONSERECEIVED;
        CrestronString SDATAIN;
        CrestronString SNUMBER;
        CrestronString SCHANNELCOMMAND;
        CrestronString SNUMBERIN;
        CrestronString SNUMBERINCURRENT;
        private CrestronString CALCCS (  SplusExecutionContext __context__, CrestronString SRAWCOMMAND ) 
            { 
            ushort A = 0;
            
            ushort ICS = 0;
            
            CrestronString SCS;
            SCS  = new CrestronString( InheritedStringEncoding, 1, this );
            
            
            __context__.SourceCodeLine = 89;
            ICS = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 90;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)Functions.Length( SRAWCOMMAND ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 92;
                ICS = (ushort) ( (ICS + Byte( SRAWCOMMAND , (int)( A ) )) ) ; 
                __context__.SourceCodeLine = 90;
                } 
            
            __context__.SourceCodeLine = 94;
            SCS  .UpdateValue ( Functions.Chr (  (int) ( ICS ) )  ) ; 
            __context__.SourceCodeLine = 95;
            return ( SCS ) ; 
            
            }
            
        object SEND_STRING_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 107;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISTATE == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 109;
                    ICOMMANDQUEUEFOUND = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 110;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)7; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 112;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICOMMANDQUEUE[ (A - 1) ] == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 114;
                            ICOMMANDQUEUEFOUND = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 115;
                            MakeString ( SCOMMANDTEMP , "\u008C\u0000{0}{1}{2}", Functions.Chr (  (int) ( (A - 1) ) ) , Functions.Chr (  (int) ( (Functions.Length( SDATAREQUEST[ (A - 1) ] ) + 1) ) ) , SDATAREQUEST [ (A - 1) ] ) ; 
                            __context__.SourceCodeLine = 116;
                            MakeString ( SCOMMANDTEMP , "{0}{1}", SCOMMANDTEMP , CALCCS (  __context__ , SCOMMANDTEMP) ) ; 
                            __context__.SourceCodeLine = 117;
                            TO_DEVICE  .UpdateValue ( SCOMMANDTEMP  ) ; 
                            __context__.SourceCodeLine = 118;
                            IFUNCTIONACTIVE = (ushort) ( (A - 1) ) ; 
                            __context__.SourceCodeLine = 119;
                            ISTATE = (ushort) ( 3 ) ; 
                            __context__.SourceCodeLine = 120;
                            break ; 
                            } 
                        
                        __context__.SourceCodeLine = 110;
                        } 
                    
                    __context__.SourceCodeLine = 123;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICOMMANDQUEUEFOUND == 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 124;
                        SEQUENCE_ACTIVE  .Value = (ushort) ( 0 ) ; 
                        }
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 126;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISTATE == 3))  ) ) 
                        { 
                        __context__.SourceCodeLine = 128;
                        MakeString ( SCOMMANDTEMP , "\u0083\u0000{0}\u00FF\u00FF", Functions.Chr (  (int) ( IFUNCTIONACTIVE ) ) ) ; 
                        __context__.SourceCodeLine = 129;
                        TO_DEVICE  .UpdateValue ( SCOMMANDTEMP + CALCCS (  __context__ , SCOMMANDTEMP)  ) ; 
                        __context__.SourceCodeLine = 130;
                        ISTATE = (ushort) ( 2 ) ; 
                        } 
                    
                    }
                
                __context__.SourceCodeLine = 132;
                CreateWait ( "NORESPONSE" , 100 , NORESPONSE_Callback ) ;
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public void NORESPONSE_CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            
            __context__.SourceCodeLine = 134;
            SEQUENCE_ACTIVE  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 135;
            IFEEDBACKFAIL = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 136;
            ISTATE = (ushort) ( 1 ) ; 
            
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
object COMMAND_IN_PUSH_OnPush_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 143;
        SCOMMANDTOSEND  .UpdateValue ( COMMAND_IN  ) ; 
        __context__.SourceCodeLine = 144;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Left( SCOMMANDTOSEND , (int)( 1 ) ) == "\u008C"))  ) ) 
            { 
            __context__.SourceCodeLine = 146;
            IFUNCTION = (ushort) ( Byte( SCOMMANDTOSEND , (int)( 3 ) ) ) ; 
            __context__.SourceCodeLine = 147;
            IDATA = (ushort) ( Byte( SCOMMANDTOSEND , (int)( 4 ) ) ) ; 
            __context__.SourceCodeLine = 148;
            SDATAREQUEST [ IFUNCTION ]  .UpdateValue ( Functions.Mid ( SCOMMANDTOSEND ,  (int) ( 5 ) ,  (int) ( (IDATA - 1) ) )  ) ; 
            __context__.SourceCodeLine = 149;
            ICOMMANDQUEUE [ IFUNCTION] = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 150;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SEQUENCE_ACTIVE  .Value == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 152;
                SEQUENCE_ACTIVE  .Value = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 155;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Left( SCOMMANDTOSEND , (int)( 1 ) ) == "\u0083") ) && Functions.TestForTrue ( Functions.BoolToInt (SEQUENCE_ACTIVE  .Value == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 157;
                IFUNCTIONACTIVE = (ushort) ( Byte( SCOMMANDTOSEND , (int)( 3 ) ) ) ; 
                __context__.SourceCodeLine = 158;
                ISTATE = (ushort) ( 2 ) ; 
                __context__.SourceCodeLine = 159;
                CreateWait ( "NORESPONSE2" , 100 , NORESPONSE2_Callback ) ;
                } 
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void NORESPONSE2_CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 161;
            SEQUENCE_ACTIVE  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 162;
            ISTATE = (ushort) ( 1 ) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object FROM_DEVICE_PUSH_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 170;
        CancelWait ( "NORESPONSE" ) ; 
        __context__.SourceCodeLine = 171;
        CancelWait ( "NORESPONSE2" ) ; 
        __context__.SourceCodeLine = 172;
        SRESPONSERECEIVED  .UpdateValue ( FROM_DEVICE  ) ; 
        __context__.SourceCodeLine = 173;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ISTATE == 2) ) && Functions.TestForTrue ( Functions.BoolToInt (SRESPONSERECEIVED == "\u0070\u0003\u0073") )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 175;
            ICOMMANDQUEUE [ IFUNCTIONACTIVE] = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 176;
            IFEEDBACKFAIL = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 177;
            ISTATE = (ushort) ( 1 ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 179;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ISTATE == 2) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( SRESPONSERECEIVED ) > 3 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 181;
                SDATAIN  .UpdateValue ( Functions.Mid ( SRESPONSERECEIVED ,  (int) ( 4 ) ,  (int) ( (Byte( SRESPONSERECEIVED , (int)( 3 ) ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 182;
                MakeString ( STATUS_STRING , "{0}{1}{2}", Functions.Chr (  (int) ( IFUNCTIONACTIVE ) ) , Functions.Chr (  (int) ( (Functions.Length( SDATAIN ) + 1) ) ) , SDATAIN ) ; 
                __context__.SourceCodeLine = 183;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SDATAIN == SDATAREQUEST[ IFUNCTIONACTIVE ]))  ) ) 
                    { 
                    __context__.SourceCodeLine = 185;
                    ICOMMANDQUEUE [ IFUNCTIONACTIVE] = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 186;
                    IFEEDBACKFAIL = (ushort) ( 0 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 190;
                    IFEEDBACKFAIL = (ushort) ( (IFEEDBACKFAIL + 1) ) ; 
                    __context__.SourceCodeLine = 191;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFEEDBACKFAIL > 2 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 193;
                        ICOMMANDQUEUE [ IFUNCTIONACTIVE] = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 194;
                        IFEEDBACKFAIL = (ushort) ( 0 ) ; 
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 197;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IFUNCTIONACTIVE == 4))  ) ) 
                    { 
                    __context__.SourceCodeLine = 199;
                    SDATAIN  .UpdateValue ( Functions.Right ( SDATAIN ,  (int) ( (Functions.Length( SDATAIN ) - 1) ) )  ) ; 
                    __context__.SourceCodeLine = 200;
                    TUNER_BAND_VALUE  .Value = (ushort) ( Functions.GetC( SDATAIN ) ) ; 
                    __context__.SourceCodeLine = 201;
                    Functions.ClearBuffer ( SNUMBERIN ) ; 
                    __context__.SourceCodeLine = 202;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)Functions.Length( SDATAIN ); 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( D  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (D  >= __FN_FORSTART_VAL__1) && (D  <= __FN_FOREND_VAL__1) ) : ( (D  <= __FN_FORSTART_VAL__1) && (D  >= __FN_FOREND_VAL__1) ) ; D  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 204;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( SDATAIN , (int)( D ) ) == 44))  ) ) 
                            {
                            __context__.SourceCodeLine = 205;
                            MakeString ( SNUMBERIN , "{0}.", SNUMBERIN ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 206;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( SDATAIN , (int)( D ) ) != 255))  ) ) 
                                {
                                __context__.SourceCodeLine = 207;
                                MakeString ( SNUMBERIN , "{0}{1}", SNUMBERIN , Functions.Chr (  (int) ( (Byte( SDATAIN , (int)( D ) ) + 48) ) ) ) ; 
                                }
                            
                            }
                        
                        __context__.SourceCodeLine = 202;
                        } 
                    
                    __context__.SourceCodeLine = 209;
                    MakeString ( NUMBER_TEXT , "{0}", SNUMBERIN ) ; 
                    __context__.SourceCodeLine = 210;
                    SNUMBERINCURRENT  .UpdateValue ( SNUMBERIN  ) ; 
                    __context__.SourceCodeLine = 211;
                    Functions.ClearBuffer ( SNUMBER ) ; 
                    } 
                
                __context__.SourceCodeLine = 213;
                ISTATE = (ushort) ( 1 ) ; 
                } 
            
            }
        
        __context__.SourceCodeLine = 215;
        ICOMMANDQUEUEFOUND2 = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 216;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)7; 
        int __FN_FORSTEP_VAL__2 = (int)1; 
        for ( B  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (B  >= __FN_FORSTART_VAL__2) && (B  <= __FN_FOREND_VAL__2) ) : ( (B  <= __FN_FORSTART_VAL__2) && (B  >= __FN_FOREND_VAL__2) ) ; B  += (ushort)__FN_FORSTEP_VAL__2) 
            { 
            __context__.SourceCodeLine = 218;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICOMMANDQUEUE[ (B - 1) ] == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 220;
                ICOMMANDQUEUEFOUND2 = (ushort) ( 1 ) ; 
                } 
            
            __context__.SourceCodeLine = 216;
            } 
        
        __context__.SourceCodeLine = 223;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICOMMANDQUEUEFOUND2 == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 225;
            SEQUENCE_ACTIVE  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 226;
            IFEEDBACKFAIL = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 227;
            ISTATE = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object KP_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 234;
        
            {
            int __SPLS_TMPVAR__SWTCH_1__ = ((int)Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ));
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                    {
                    __context__.SourceCodeLine = 237;
                    MakeString ( SNUMBER , "{0}0", SNUMBER ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                    {
                    __context__.SourceCodeLine = 239;
                    MakeString ( SNUMBER , "{0}1", SNUMBER ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                    {
                    __context__.SourceCodeLine = 241;
                    MakeString ( SNUMBER , "{0}2", SNUMBER ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                    {
                    __context__.SourceCodeLine = 243;
                    MakeString ( SNUMBER , "{0}3", SNUMBER ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 5) ) ) ) 
                    {
                    __context__.SourceCodeLine = 245;
                    MakeString ( SNUMBER , "{0}4", SNUMBER ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 6) ) ) ) 
                    {
                    __context__.SourceCodeLine = 247;
                    MakeString ( SNUMBER , "{0}5", SNUMBER ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 7) ) ) ) 
                    {
                    __context__.SourceCodeLine = 249;
                    MakeString ( SNUMBER , "{0}6", SNUMBER ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 8) ) ) ) 
                    {
                    __context__.SourceCodeLine = 251;
                    MakeString ( SNUMBER , "{0}7", SNUMBER ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 9) ) ) ) 
                    {
                    __context__.SourceCodeLine = 253;
                    MakeString ( SNUMBER , "{0}8", SNUMBER ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 10) ) ) ) 
                    {
                    __context__.SourceCodeLine = 255;
                    MakeString ( SNUMBER , "{0}9", SNUMBER ) ; 
                    }
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 11) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 258;
                    ILOC = (ushort) ( Functions.Find( "." , SNUMBER ) ) ; 
                    __context__.SourceCodeLine = 259;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ILOC == 0) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( SNUMBER ) > 0 ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 261;
                        MakeString ( SNUMBER , "{0}.", SNUMBER ) ; 
                        } 
                    
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 12) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 266;
                    Functions.ClearBuffer ( SNUMBER ) ; 
                    __context__.SourceCodeLine = 267;
                    Functions.ClearBuffer ( SNUMBERINCURRENT ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 13) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 271;
                    Functions.ClearBuffer ( SCHANNELCOMMAND ) ; 
                    __context__.SourceCodeLine = 272;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)10; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( C  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (C  >= __FN_FORSTART_VAL__1) && (C  <= __FN_FOREND_VAL__1) ) : ( (C  <= __FN_FORSTART_VAL__1) && (C  >= __FN_FOREND_VAL__1) ) ; C  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 274;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( SNUMBER , (int)( C ) ) == 46))  ) ) 
                            {
                            __context__.SourceCodeLine = 275;
                            MakeString ( SCHANNELCOMMAND , "{0}\u002C", SCHANNELCOMMAND ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 276;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( SNUMBER , (int)( C ) ) == 65535))  ) ) 
                                {
                                __context__.SourceCodeLine = 277;
                                MakeString ( SCHANNELCOMMAND , "{0}\u00FF", SCHANNELCOMMAND ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 278;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( SNUMBER , (int)( C ) ) != 42))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 279;
                                    MakeString ( SCHANNELCOMMAND , "{0}{1}", SCHANNELCOMMAND , Functions.Chr (  (int) ( (Byte( SNUMBER , (int)( C ) ) - 48) ) ) ) ; 
                                    }
                                
                                }
                            
                            }
                        
                        __context__.SourceCodeLine = 272;
                        } 
                    
                    __context__.SourceCodeLine = 281;
                    if ( Functions.TestForTrue  ( ( AIR  .Value)  ) ) 
                        {
                        __context__.SourceCodeLine = 282;
                        MakeString ( SCHANNELCOMMAND , "\u0001\u0001{0}", SCHANNELCOMMAND ) ; 
                        }
                    
                    __context__.SourceCodeLine = 283;
                    if ( Functions.TestForTrue  ( ( CABLE  .Value)  ) ) 
                        {
                        __context__.SourceCodeLine = 284;
                        MakeString ( SCHANNELCOMMAND , "\u0001\u0003{0}", SCHANNELCOMMAND ) ; 
                        }
                    
                    __context__.SourceCodeLine = 286;
                    IFUNCTION = (ushort) ( 4 ) ; 
                    __context__.SourceCodeLine = 287;
                    SDATAREQUEST [ IFUNCTION ]  .UpdateValue ( SCHANNELCOMMAND  ) ; 
                    __context__.SourceCodeLine = 288;
                    ICOMMANDQUEUE [ IFUNCTION] = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 289;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SEQUENCE_ACTIVE  .Value == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 291;
                        SEQUENCE_ACTIVE  .Value = (ushort) ( 1 ) ; 
                        } 
                    
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 14) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 296;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SNUMBER ) > 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 298;
                        if ( Functions.TestForTrue  ( ( AIR  .Value)  ) ) 
                            {
                            __context__.SourceCodeLine = 299;
                            MakeString ( SCHANNELCOMMAND , "\u0001\u0001\u00FF\u00FF\u00FF\u00FF\u00FF\u00FF\u00FF\u00FF\u00FF\u00FF") ; 
                            }
                        
                        __context__.SourceCodeLine = 300;
                        if ( Functions.TestForTrue  ( ( CABLE  .Value)  ) ) 
                            {
                            __context__.SourceCodeLine = 301;
                            MakeString ( SCHANNELCOMMAND , "\u0001\u0003\u00FF\u00FF\u00FF\u00FF\u00FF\u00FF\u00FF\u00FF\u00FF\u00FF") ; 
                            }
                        
                        __context__.SourceCodeLine = 303;
                        IFUNCTION = (ushort) ( 4 ) ; 
                        __context__.SourceCodeLine = 304;
                        SDATAREQUEST [ IFUNCTION ]  .UpdateValue ( SCHANNELCOMMAND  ) ; 
                        __context__.SourceCodeLine = 305;
                        ICOMMANDQUEUE [ IFUNCTION] = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 306;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SEQUENCE_ACTIVE  .Value == 0))  ) ) 
                            { 
                            __context__.SourceCodeLine = 308;
                            SEQUENCE_ACTIVE  .Value = (ushort) ( 1 ) ; 
                            } 
                        
                        } 
                    
                    } 
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 313;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SNUMBER ) > 0 ))  ) ) 
            {
            __context__.SourceCodeLine = 314;
            MakeString ( NUMBER_TEXT , "{0}*", SNUMBER ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 316;
            MakeString ( NUMBER_TEXT , "\u0020") ; 
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
        
        __context__.SourceCodeLine = 329;
        ISTATE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 330;
        SEQUENCE_ACTIVE  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 331;
        IFEEDBACKFAIL = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    ICOMMANDQUEUE  = new ushort[ 7 ];
    SCOMMANDTOSEND  = new CrestronString( InheritedStringEncoding, 20, this );
    SCOMMANDTEMP  = new CrestronString( InheritedStringEncoding, 20, this );
    SRESPONSERECEIVED  = new CrestronString( InheritedStringEncoding, 20, this );
    SDATAIN  = new CrestronString( InheritedStringEncoding, 20, this );
    SNUMBER  = new CrestronString( InheritedStringEncoding, 11, this );
    SCHANNELCOMMAND  = new CrestronString( InheritedStringEncoding, 13, this );
    SNUMBERIN  = new CrestronString( InheritedStringEncoding, 10, this );
    SNUMBERINCURRENT  = new CrestronString( InheritedStringEncoding, 10, this );
    SDATAREQUEST  = new CrestronString[ 7 ];
    for( uint i = 0; i < 7; i++ )
        SDATAREQUEST [i] = new CrestronString( InheritedStringEncoding, 20, this );
    
    SEND_STRING = new Crestron.Logos.SplusObjects.DigitalInput( SEND_STRING__DigitalInput__, this );
    m_DigitalInputList.Add( SEND_STRING__DigitalInput__, SEND_STRING );
    
    FROM_DEVICE_PUSH = new Crestron.Logos.SplusObjects.DigitalInput( FROM_DEVICE_PUSH__DigitalInput__, this );
    m_DigitalInputList.Add( FROM_DEVICE_PUSH__DigitalInput__, FROM_DEVICE_PUSH );
    
    COMMAND_IN_PUSH = new Crestron.Logos.SplusObjects.DigitalInput( COMMAND_IN_PUSH__DigitalInput__, this );
    m_DigitalInputList.Add( COMMAND_IN_PUSH__DigitalInput__, COMMAND_IN_PUSH );
    
    AIR = new Crestron.Logos.SplusObjects.DigitalInput( AIR__DigitalInput__, this );
    m_DigitalInputList.Add( AIR__DigitalInput__, AIR );
    
    CABLE = new Crestron.Logos.SplusObjects.DigitalInput( CABLE__DigitalInput__, this );
    m_DigitalInputList.Add( CABLE__DigitalInput__, CABLE );
    
    KP = new InOutArray<DigitalInput>( 14, this );
    for( uint i = 0; i < 14; i++ )
    {
        KP[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( KP__DigitalInput__ + i, KP__DigitalInput__, this );
        m_DigitalInputList.Add( KP__DigitalInput__ + i, KP[i+1] );
    }
    
    SEQUENCE_ACTIVE = new Crestron.Logos.SplusObjects.DigitalOutput( SEQUENCE_ACTIVE__DigitalOutput__, this );
    m_DigitalOutputList.Add( SEQUENCE_ACTIVE__DigitalOutput__, SEQUENCE_ACTIVE );
    
    TUNER_BAND_VALUE = new Crestron.Logos.SplusObjects.AnalogOutput( TUNER_BAND_VALUE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( TUNER_BAND_VALUE__AnalogSerialOutput__, TUNER_BAND_VALUE );
    
    COMMAND_IN = new Crestron.Logos.SplusObjects.StringInput( COMMAND_IN__AnalogSerialInput__, 20, this );
    m_StringInputList.Add( COMMAND_IN__AnalogSerialInput__, COMMAND_IN );
    
    FROM_DEVICE = new Crestron.Logos.SplusObjects.StringInput( FROM_DEVICE__AnalogSerialInput__, 20, this );
    m_StringInputList.Add( FROM_DEVICE__AnalogSerialInput__, FROM_DEVICE );
    
    TO_DEVICE = new Crestron.Logos.SplusObjects.StringOutput( TO_DEVICE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TO_DEVICE__AnalogSerialOutput__, TO_DEVICE );
    
    STATUS_STRING = new Crestron.Logos.SplusObjects.StringOutput( STATUS_STRING__AnalogSerialOutput__, this );
    m_StringOutputList.Add( STATUS_STRING__AnalogSerialOutput__, STATUS_STRING );
    
    NUMBER_TEXT = new Crestron.Logos.SplusObjects.StringOutput( NUMBER_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( NUMBER_TEXT__AnalogSerialOutput__, NUMBER_TEXT );
    
    NORESPONSE_Callback = new WaitFunction( NORESPONSE_CallbackFn );
    NORESPONSE2_Callback = new WaitFunction( NORESPONSE2_CallbackFn );
    
    SEND_STRING.OnDigitalPush.Add( new InputChangeHandlerWrapper( SEND_STRING_OnPush_0, false ) );
    COMMAND_IN_PUSH.OnDigitalPush.Add( new InputChangeHandlerWrapper( COMMAND_IN_PUSH_OnPush_1, false ) );
    FROM_DEVICE_PUSH.OnDigitalPush.Add( new InputChangeHandlerWrapper( FROM_DEVICE_PUSH_OnPush_2, false ) );
    for( uint i = 0; i < 14; i++ )
        KP[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( KP_OnPush_3, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_SONY_XBR_84X900_V1_0_PROCESSOR ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction NORESPONSE_Callback;
private WaitFunction NORESPONSE2_Callback;


const uint SEND_STRING__DigitalInput__ = 0;
const uint FROM_DEVICE_PUSH__DigitalInput__ = 1;
const uint COMMAND_IN_PUSH__DigitalInput__ = 2;
const uint AIR__DigitalInput__ = 3;
const uint CABLE__DigitalInput__ = 4;
const uint KP__DigitalInput__ = 5;
const uint COMMAND_IN__AnalogSerialInput__ = 0;
const uint FROM_DEVICE__AnalogSerialInput__ = 1;
const uint SEQUENCE_ACTIVE__DigitalOutput__ = 0;
const uint TUNER_BAND_VALUE__AnalogSerialOutput__ = 0;
const uint TO_DEVICE__AnalogSerialOutput__ = 1;
const uint STATUS_STRING__AnalogSerialOutput__ = 2;
const uint NUMBER_TEXT__AnalogSerialOutput__ = 3;

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
