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

namespace UserModule_HONEYWELL_4232CBM_PROCESSOR_V1_4
{
    public class UserModuleClass_HONEYWELL_4232CBM_PROCESSOR_V1_4 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZE;
        Crestron.Logos.SplusObjects.DigitalInput ENABLE_DEBUGGING;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> KEY;
        Crestron.Logos.SplusObjects.AnalogInput SYSTEM_TYPE;
        Crestron.Logos.SplusObjects.BufferInput FROM_DEVICE;
        Crestron.Logos.SplusObjects.DigitalOutput BACK_LIGHT_ON;
        Crestron.Logos.SplusObjects.DigitalOutput RECEIVING_DATA;
        Crestron.Logos.SplusObjects.AnalogOutput L1_VALUE;
        Crestron.Logos.SplusObjects.AnalogOutput L2_VALUE;
        Crestron.Logos.SplusObjects.AnalogOutput L3_VALUE;
        Crestron.Logos.SplusObjects.StringOutput LINE_1_TEXT;
        Crestron.Logos.SplusObjects.StringOutput LINE_2_TEXT;
        Crestron.Logos.SplusObjects.StringOutput TO_DEVICE;
        ushort IKEY = 0;
        ushort IINITSENT = 0;
        ushort IBACKLIGHT = 0;
        ushort IJUNK = 0;
        ushort ILENGTH = 0;
        ushort ICHECKSUM = 0;
        ushort A = 0;
        ushort SYSTEMTYPE = 0;
        ushort INITCOMMANDSCOUNT = 0;
        CrestronString SKEYPRESSES;
        CrestronString SESPCOMMAND;
        CrestronString SCOMMAND;
        CrestronString [] SINITCOMMAND;
        CrestronString STEMP;
        CrestronString SADDRESS;
        CrestronString SLINE1TEXT;
        CrestronString STEMPLINE1TEXT;
        CrestronString SLINE2TEXT;
        CrestronString STEMPLINE2TEXT;
        private void FRECEIVINGTIMEOUT (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 136;
            CreateWait ( "WRECEIVINGDATATIMEOUT" , 3000 , WRECEIVINGDATATIMEOUT_Callback ) ;
            
            }
            
        public void WRECEIVINGDATATIMEOUT_CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 138;
            RECEIVING_DATA  .Value = (ushort) ( 0 ) ; 
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    private void FSENDCOMMAND (  SplusExecutionContext __context__ ) 
        { 
        ushort FIA = 0;
        ushort FICHECKSUM = 0;
        ushort FILEN = 0;
        
        
        __context__.SourceCodeLine = 146;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SKEYPRESSES ) > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 148;
            SCOMMAND  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 149;
            SESPCOMMAND  .UpdateValue ( SADDRESS + Functions.Chr (  (int) ( (Functions.Length( SKEYPRESSES ) + 1) ) ) + SKEYPRESSES  ) ; 
            __context__.SourceCodeLine = 150;
            FICHECKSUM = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 151;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)Functions.Length( SESPCOMMAND ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( FIA  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (FIA  >= __FN_FORSTART_VAL__1) && (FIA  <= __FN_FOREND_VAL__1) ) : ( (FIA  <= __FN_FORSTART_VAL__1) && (FIA  >= __FN_FOREND_VAL__1) ) ; FIA  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 153;
                FICHECKSUM = (ushort) ( (FICHECKSUM + Byte( SESPCOMMAND , (int)( FIA ) )) ) ; 
                __context__.SourceCodeLine = 154;
                if ( Functions.TestForTrue  ( ( ENABLE_DEBUGGING  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 156;
                    GenerateUserNotice ( "fSendCommand: calculating check sum: fiCheckSum = {0:d}; sESPCommand byte[{1:d}] = {2:d}", (short)FICHECKSUM, (short)FIA, (short)Byte( SESPCOMMAND , (int)( FIA ) )) ; 
                    } 
                
                __context__.SourceCodeLine = 151;
                } 
            
            __context__.SourceCodeLine = 159;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FICHECKSUM > 256 ))  ) ) 
                { 
                __context__.SourceCodeLine = 161;
                FICHECKSUM = (ushort) ( Mod( FICHECKSUM , 256 ) ) ; 
                __context__.SourceCodeLine = 162;
                if ( Functions.TestForTrue  ( ( ENABLE_DEBUGGING  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 164;
                    GenerateUserNotice ( "fSendCommand: check sum mod 256: fiCheckSum = {0:d};", (short)FICHECKSUM) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 167;
            FICHECKSUM = (ushort) ( (256 - FICHECKSUM) ) ; 
            __context__.SourceCodeLine = 168;
            if ( Functions.TestForTrue  ( ( ENABLE_DEBUGGING  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 170;
                GenerateUserNotice ( "fSendCommand: 256 - check sum: fiCheckSum = {0:d};", (short)FICHECKSUM) ; 
                } 
            
            __context__.SourceCodeLine = 172;
            SESPCOMMAND  .UpdateValue ( "\u00FF\u0012" + "\u00F6" + Functions.Mid ( SADDRESS ,  (int) ( 1 ) ,  (int) ( 1 ) ) + SESPCOMMAND + Functions.Chr (  (int) ( FICHECKSUM ) )  ) ; 
            __context__.SourceCodeLine = 173;
            FILEN = (ushort) ( Functions.Length( SESPCOMMAND ) ) ; 
            __context__.SourceCodeLine = 174;
            if ( Functions.TestForTrue  ( ( ENABLE_DEBUGGING  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 176;
                GenerateUserNotice ( "fSendCommand: fiLen = {0:d};", (short)FILEN) ; 
                } 
            
            __context__.SourceCodeLine = 178;
            SCOMMAND  .UpdateValue ( "\u0000" + Functions.Chr (  (int) ( (FILEN / 256) ) ) + Functions.Chr (  (int) ( Mod( FILEN , 256 ) ) ) + SESPCOMMAND  ) ; 
            __context__.SourceCodeLine = 179;
            FICHECKSUM = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 180;
            ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__2 = (ushort)Functions.Length( SCOMMAND ); 
            int __FN_FORSTEP_VAL__2 = (int)1; 
            for ( FIA  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (FIA  >= __FN_FORSTART_VAL__2) && (FIA  <= __FN_FOREND_VAL__2) ) : ( (FIA  <= __FN_FORSTART_VAL__2) && (FIA  >= __FN_FOREND_VAL__2) ) ; FIA  += (ushort)__FN_FORSTEP_VAL__2) 
                { 
                __context__.SourceCodeLine = 182;
                FICHECKSUM = (ushort) ( (FICHECKSUM + Byte( SCOMMAND , (int)( FIA ) )) ) ; 
                __context__.SourceCodeLine = 183;
                if ( Functions.TestForTrue  ( ( ENABLE_DEBUGGING  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 185;
                    GenerateUserNotice ( "fSendCommand: sCommand byte[{0:d}] = {1:d};", (short)FIA, (short)Byte( SCOMMAND , (int)( FIA ) )) ; 
                    __context__.SourceCodeLine = 186;
                    GenerateUserNotice ( "fSendCommand: calculating check sum #2: fiCheckSum = {0:d};", (short)FICHECKSUM) ; 
                    } 
                
                __context__.SourceCodeLine = 180;
                } 
            
            __context__.SourceCodeLine = 189;
            SCOMMAND  .UpdateValue ( "\u0002" + SCOMMAND + Functions.Chr (  (int) ( Mod( FICHECKSUM , 256 ) ) )  ) ; 
            __context__.SourceCodeLine = 190;
            SKEYPRESSES  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 191;
            SESPCOMMAND  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 192;
            if ( Functions.TestForTrue  ( ( ENABLE_DEBUGGING  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 194;
                ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__3 = (ushort)Functions.Length( SCOMMAND ); 
                int __FN_FORSTEP_VAL__3 = (int)1; 
                for ( FIA  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (FIA  >= __FN_FORSTART_VAL__3) && (FIA  <= __FN_FOREND_VAL__3) ) : ( (FIA  <= __FN_FORSTART_VAL__3) && (FIA  >= __FN_FOREND_VAL__3) ) ; FIA  += (ushort)__FN_FORSTEP_VAL__3) 
                    { 
                    __context__.SourceCodeLine = 196;
                    GenerateUserNotice ( "fSendCommand: sCommand byte[{0:d}] = {1:d};", (short)FIA, (short)Byte( SCOMMAND , (int)( FIA ) )) ; 
                    __context__.SourceCodeLine = 194;
                    } 
                
                } 
            
            __context__.SourceCodeLine = 199;
            TO_DEVICE  .UpdateValue ( SCOMMAND  ) ; 
            } 
        
        
        }
        
    private void FSENDDELAY (  SplusExecutionContext __context__ ) 
        { 
        
        __context__.SourceCodeLine = 205;
        CreateWait ( "WSENDDELAY" , 100 , WSENDDELAY_Callback ) ;
        
        }
        
    public void WSENDDELAY_CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            
            __context__.SourceCodeLine = 207;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SKEYPRESSES ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 209;
                FSENDCOMMAND (  __context__  ) ; 
                } 
            
            
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
private void FINITDELAY (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 216;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IINITSENT < INITCOMMANDSCOUNT ))  ) ) 
        { 
        __context__.SourceCodeLine = 218;
        IINITSENT = (ushort) ( (IINITSENT + 1) ) ; 
        __context__.SourceCodeLine = 219;
        TO_DEVICE  .UpdateValue ( SINITCOMMAND [ IINITSENT ]  ) ; 
        __context__.SourceCodeLine = 220;
        CreateWait ( "WINITDELAY" , 250 , WINITDELAY_Callback ) ;
        } 
    
    
    }
    
public void WINITDELAY_CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 222;
            FINITDELAY (  __context__  ) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

private void FPROCESSRESPONSE (  SplusExecutionContext __context__, CrestronString FSTEMP ) 
    { 
    CrestronString FSTEMPCOMMAND;
    FSTEMPCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
    
    
    __context__.SourceCodeLine = 231;
    FSTEMPCOMMAND  .UpdateValue ( Functions.Mid ( FSTEMP ,  (int) ( 5 ) ,  (int) ( 3 ) )  ) ; 
    __context__.SourceCodeLine = 232;
    
        {
        int __SPLS_TMPVAR__SWTCH_1__ = ((int)1);
        
            { 
            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.BoolToInt (FSTEMPCOMMAND == "\u00FF\u0012\u00F7")) ) ) ) 
                { 
                __context__.SourceCodeLine = 236;
                L1_VALUE  .Value = (ushort) ( Byte( FSTEMP , (int)( 13 ) ) ) ; 
                __context__.SourceCodeLine = 237;
                L2_VALUE  .Value = (ushort) ( Byte( FSTEMP , (int)( 14 ) ) ) ; 
                __context__.SourceCodeLine = 238;
                L3_VALUE  .Value = (ushort) ( Byte( FSTEMP , (int)( 15 ) ) ) ; 
                __context__.SourceCodeLine = 239;
                IBACKLIGHT = (ushort) ( Bit( FSTEMP , (int)( 19 ) , (int)( 7 ) ) ) ; 
                __context__.SourceCodeLine = 240;
                BACK_LIGHT_ON  .Value = (ushort) ( IBACKLIGHT ) ; 
                __context__.SourceCodeLine = 241;
                STEMPLINE1TEXT  .UpdateValue ( Functions.Mid ( FSTEMP ,  (int) ( 19 ) ,  (int) ( 16 ) )  ) ; 
                __context__.SourceCodeLine = 242;
                STEMPLINE2TEXT  .UpdateValue ( Functions.Mid ( FSTEMP ,  (int) ( 35 ) ,  (int) ( 16 ) )  ) ; 
                __context__.SourceCodeLine = 243;
                STEMPLINE1TEXT  .UpdateValue ( Functions.Chr (  (int) ( (Byte( STEMPLINE1TEXT , (int)( 1 ) ) & 127) ) ) + Functions.Right ( STEMPLINE1TEXT ,  (int) ( (Functions.Length( STEMPLINE1TEXT ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 244;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (STEMPLINE1TEXT != SLINE1TEXT))  ) ) 
                    { 
                    __context__.SourceCodeLine = 246;
                    SLINE1TEXT  .UpdateValue ( STEMPLINE1TEXT  ) ; 
                    __context__.SourceCodeLine = 247;
                    STEMPLINE1TEXT  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 248;
                    LINE_1_TEXT  .UpdateValue ( SLINE1TEXT  ) ; 
                    } 
                
                __context__.SourceCodeLine = 250;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (STEMPLINE2TEXT != SLINE2TEXT))  ) ) 
                    { 
                    __context__.SourceCodeLine = 252;
                    SLINE2TEXT  .UpdateValue ( STEMPLINE2TEXT  ) ; 
                    __context__.SourceCodeLine = 253;
                    STEMPLINE2TEXT  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 254;
                    LINE_2_TEXT  .UpdateValue ( SLINE2TEXT  ) ; 
                    } 
                
                } 
            
            } 
            
        }
        
    
    
    }
    
private void SETSYSTEMTYPE (  SplusExecutionContext __context__ ) 
    { 
    ushort OPTIONS = 0;
    ushort CHECKSUM = 0;
    ushort A = 0;
    
    CrestronString STEMPCOMMAND;
    STEMPCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    
    
    __context__.SourceCodeLine = 264;
    OPTIONS = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 265;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SYSTEM_TYPE  .UshortValue == 2))  ) ) 
        { 
        __context__.SourceCodeLine = 267;
        SYSTEMTYPE = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 268;
        SADDRESS  .UpdateValue ( Functions.Chr (  (int) ( 5 ) )  ) ; 
        __context__.SourceCodeLine = 270;
        SESPCOMMAND  .UpdateValue ( "\u00FF\u0010\u0001\u0000\u0000" + "\u0019" + "\u0000"  ) ; 
        __context__.SourceCodeLine = 272;
        STEMPCOMMAND  .UpdateValue ( "\u0000" + Functions.Chr (  (int) ( (Functions.Length( SESPCOMMAND ) / 256) ) ) + Functions.Chr (  (int) ( Mod( Functions.Length( SESPCOMMAND ) , 256 ) ) ) + SESPCOMMAND  ) ; 
        __context__.SourceCodeLine = 273;
        CHECKSUM = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 274;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)Functions.Length( STEMPCOMMAND ); 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 276;
            CHECKSUM = (ushort) ( (CHECKSUM + Byte( STEMPCOMMAND , (int)( A ) )) ) ; 
            __context__.SourceCodeLine = 277;
            if ( Functions.TestForTrue  ( ( ENABLE_DEBUGGING  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 279;
                GenerateUserNotice ( "System_Type: Commercial: checksum = {0:d}; sTempCommand byte[{1:d}] = {2:d};", (short)CHECKSUM, (short)A, (short)Byte( STEMPCOMMAND , (int)( A ) )) ; 
                } 
            
            __context__.SourceCodeLine = 274;
            } 
        
        __context__.SourceCodeLine = 282;
        SINITCOMMAND [ 1 ]  .UpdateValue ( "\u0002" + STEMPCOMMAND + Functions.Chr (  (int) ( Mod( CHECKSUM , 256 ) ) )  ) ; 
        __context__.SourceCodeLine = 283;
        SESPCOMMAND  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 284;
        STEMPCOMMAND  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 285;
        OPTIONS = (ushort) ( (128 | 64) ) ; 
        __context__.SourceCodeLine = 286;
        OPTIONS = (ushort) ( (OPTIONS | (5 & 31)) ) ; 
        __context__.SourceCodeLine = 287;
        SESPCOMMAND  .UpdateValue ( "\u00FF\u0011\u0002" + Functions.Chr (  (int) ( OPTIONS ) )  ) ; 
        __context__.SourceCodeLine = 288;
        OPTIONS = (ushort) ( 128 ) ; 
        __context__.SourceCodeLine = 289;
        OPTIONS = (ushort) ( (OPTIONS | (6 & 31)) ) ; 
        __context__.SourceCodeLine = 290;
        SESPCOMMAND  .UpdateValue ( SESPCOMMAND + Functions.Chr (  (int) ( OPTIONS ) )  ) ; 
        __context__.SourceCodeLine = 292;
        STEMPCOMMAND  .UpdateValue ( "\u0000" + Functions.Chr (  (int) ( (Functions.Length( SESPCOMMAND ) / 256) ) ) + Functions.Chr (  (int) ( Mod( Functions.Length( SESPCOMMAND ) , 256 ) ) ) + SESPCOMMAND  ) ; 
        __context__.SourceCodeLine = 293;
        CHECKSUM = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 294;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)Functions.Length( STEMPCOMMAND ); 
        int __FN_FORSTEP_VAL__2 = (int)1; 
        for ( A  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (A  >= __FN_FORSTART_VAL__2) && (A  <= __FN_FOREND_VAL__2) ) : ( (A  <= __FN_FORSTART_VAL__2) && (A  >= __FN_FOREND_VAL__2) ) ; A  += (ushort)__FN_FORSTEP_VAL__2) 
            { 
            __context__.SourceCodeLine = 296;
            CHECKSUM = (ushort) ( (CHECKSUM + Byte( STEMPCOMMAND , (int)( A ) )) ) ; 
            __context__.SourceCodeLine = 297;
            if ( Functions.TestForTrue  ( ( ENABLE_DEBUGGING  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 299;
                GenerateUserNotice ( "System_Type: Commercial: second checksum: checksum = {0:d}; sTempCommand byte[{1:d}] = {2:d};", (short)CHECKSUM, (short)A, (short)Byte( STEMPCOMMAND , (int)( A ) )) ; 
                } 
            
            __context__.SourceCodeLine = 294;
            } 
        
        __context__.SourceCodeLine = 302;
        SINITCOMMAND [ 2 ]  .UpdateValue ( "\u0002" + STEMPCOMMAND + Functions.Chr (  (int) ( Mod( CHECKSUM , 256 ) ) )  ) ; 
        __context__.SourceCodeLine = 303;
        INITCOMMANDSCOUNT = (ushort) ( 2 ) ; 
        } 
    
    else 
        { 
        __context__.SourceCodeLine = 307;
        SYSTEMTYPE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 308;
        SADDRESS  .UpdateValue ( Functions.Chr (  (int) ( 1 ) )  ) ; 
        __context__.SourceCodeLine = 309;
        SESPCOMMAND  .UpdateValue ( "\u00FF\u0010\u0001\u0000\u0000" + "\u0019" + "\u0000"  ) ; 
        __context__.SourceCodeLine = 311;
        STEMPCOMMAND  .UpdateValue ( "\u0000" + Functions.Chr (  (int) ( (Functions.Length( SESPCOMMAND ) / 256) ) ) + Functions.Chr (  (int) ( Mod( Functions.Length( SESPCOMMAND ) , 256 ) ) ) + SESPCOMMAND  ) ; 
        __context__.SourceCodeLine = 312;
        CHECKSUM = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 313;
        ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__3 = (ushort)Functions.Length( STEMPCOMMAND ); 
        int __FN_FORSTEP_VAL__3 = (int)1; 
        for ( A  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (A  >= __FN_FORSTART_VAL__3) && (A  <= __FN_FOREND_VAL__3) ) : ( (A  <= __FN_FORSTART_VAL__3) && (A  >= __FN_FOREND_VAL__3) ) ; A  += (ushort)__FN_FORSTEP_VAL__3) 
            { 
            __context__.SourceCodeLine = 315;
            CHECKSUM = (ushort) ( (CHECKSUM + Byte( STEMPCOMMAND , (int)( A ) )) ) ; 
            __context__.SourceCodeLine = 316;
            if ( Functions.TestForTrue  ( ( ENABLE_DEBUGGING  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 318;
                GenerateUserNotice ( "System_Type: Residential: checksum = {0:d}; sTempCommand byte[{1:d}] = {2:d};", (short)CHECKSUM, (short)A, (short)Byte( STEMPCOMMAND , (int)( A ) )) ; 
                } 
            
            __context__.SourceCodeLine = 313;
            } 
        
        __context__.SourceCodeLine = 321;
        SINITCOMMAND [ 1 ]  .UpdateValue ( "\u0002" + STEMPCOMMAND + Functions.Chr (  (int) ( Mod( CHECKSUM , 256 ) ) )  ) ; 
        __context__.SourceCodeLine = 322;
        SESPCOMMAND  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 323;
        STEMPCOMMAND  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 324;
        OPTIONS = (ushort) ( (128 | 64) ) ; 
        __context__.SourceCodeLine = 325;
        OPTIONS = (ushort) ( (OPTIONS | (1 & 31)) ) ; 
        __context__.SourceCodeLine = 326;
        SESPCOMMAND  .UpdateValue ( "\u00FF\u0011\u0002" + Functions.Chr (  (int) ( OPTIONS ) )  ) ; 
        __context__.SourceCodeLine = 327;
        OPTIONS = (ushort) ( 128 ) ; 
        __context__.SourceCodeLine = 328;
        OPTIONS = (ushort) ( (OPTIONS | (17 & 31)) ) ; 
        __context__.SourceCodeLine = 329;
        SESPCOMMAND  .UpdateValue ( SESPCOMMAND + Functions.Chr (  (int) ( OPTIONS ) )  ) ; 
        __context__.SourceCodeLine = 331;
        STEMPCOMMAND  .UpdateValue ( "\u0000" + Functions.Chr (  (int) ( (Functions.Length( SESPCOMMAND ) / 256) ) ) + Functions.Chr (  (int) ( Mod( Functions.Length( SESPCOMMAND ) , 256 ) ) ) + SESPCOMMAND  ) ; 
        __context__.SourceCodeLine = 332;
        CHECKSUM = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 333;
        ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__4 = (ushort)Functions.Length( STEMPCOMMAND ); 
        int __FN_FORSTEP_VAL__4 = (int)1; 
        for ( A  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (A  >= __FN_FORSTART_VAL__4) && (A  <= __FN_FOREND_VAL__4) ) : ( (A  <= __FN_FORSTART_VAL__4) && (A  >= __FN_FOREND_VAL__4) ) ; A  += (ushort)__FN_FORSTEP_VAL__4) 
            { 
            __context__.SourceCodeLine = 335;
            CHECKSUM = (ushort) ( (CHECKSUM + Byte( STEMPCOMMAND , (int)( A ) )) ) ; 
            __context__.SourceCodeLine = 336;
            if ( Functions.TestForTrue  ( ( ENABLE_DEBUGGING  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 338;
                GenerateUserNotice ( "System_Type: Residential: second checksum: checksum = {0:d}; sTempCommand byte[{1:d}] = {2:d};", (short)CHECKSUM, (short)A, (short)Byte( STEMPCOMMAND , (int)( A ) )) ; 
                } 
            
            __context__.SourceCodeLine = 333;
            } 
        
        __context__.SourceCodeLine = 341;
        SINITCOMMAND [ 2 ]  .UpdateValue ( "\u0002" + STEMPCOMMAND + Functions.Chr (  (int) ( Mod( CHECKSUM , 256 ) ) )  ) ; 
        __context__.SourceCodeLine = 342;
        SESPCOMMAND  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 343;
        STEMPCOMMAND  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 344;
        SESPCOMMAND  .UpdateValue ( "\u00FF\u0012\u00F6\u0001\u00A1\u0009\u0000\u006D\u006B\u000E\u0045\u0043\u00F5\u0031\u00CB"  ) ; 
        __context__.SourceCodeLine = 346;
        STEMPCOMMAND  .UpdateValue ( "\u0040" + Functions.Chr (  (int) ( (Functions.Length( SESPCOMMAND ) / 256) ) ) + Functions.Chr (  (int) ( Mod( Functions.Length( SESPCOMMAND ) , 256 ) ) ) + SESPCOMMAND  ) ; 
        __context__.SourceCodeLine = 347;
        CHECKSUM = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 348;
        ushort __FN_FORSTART_VAL__5 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__5 = (ushort)Functions.Length( STEMPCOMMAND ); 
        int __FN_FORSTEP_VAL__5 = (int)1; 
        for ( A  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (A  >= __FN_FORSTART_VAL__5) && (A  <= __FN_FOREND_VAL__5) ) : ( (A  <= __FN_FORSTART_VAL__5) && (A  >= __FN_FOREND_VAL__5) ) ; A  += (ushort)__FN_FORSTEP_VAL__5) 
            { 
            __context__.SourceCodeLine = 350;
            CHECKSUM = (ushort) ( (CHECKSUM + Byte( STEMPCOMMAND , (int)( A ) )) ) ; 
            __context__.SourceCodeLine = 351;
            if ( Functions.TestForTrue  ( ( ENABLE_DEBUGGING  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 353;
                GenerateUserNotice ( "System_Type: Residential: third checksum: checksum = {0:d}; sTempCommand byte[{1:d}] = {2:d};", (short)CHECKSUM, (short)A, (short)Byte( STEMPCOMMAND , (int)( A ) )) ; 
                } 
            
            __context__.SourceCodeLine = 348;
            } 
        
        __context__.SourceCodeLine = 356;
        SINITCOMMAND [ 3 ]  .UpdateValue ( "\u0002" + STEMPCOMMAND + Functions.Chr (  (int) ( Mod( CHECKSUM , 256 ) ) )  ) ; 
        __context__.SourceCodeLine = 357;
        INITCOMMANDSCOUNT = (ushort) ( 3 ) ; 
        } 
    
    
    }
    
object INITIALIZE_OnPush_0 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 366;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SINITCOMMAND[ 1 ] ) == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 368;
            SETSYSTEMTYPE (  __context__  ) ; 
            } 
        
        __context__.SourceCodeLine = 370;
        IINITSENT = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 371;
        FINITDELAY (  __context__  ) ; 
        __context__.SourceCodeLine = 372;
        RECEIVING_DATA  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 373;
        FRECEIVINGTIMEOUT (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object KEY_OnPush_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 378;
        IKEY = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 379;
        CancelWait ( "WSENDDELAY" ) ; 
        __context__.SourceCodeLine = 380;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SKEYPRESSES ) < 5 ))  ) ) 
            { 
            __context__.SourceCodeLine = 382;
            
                {
                int __SPLS_TMPVAR__SWTCH_2__ = ((int)IKEY);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 386;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u0000"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 390;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u0001"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 3) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 394;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u0002"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 4) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 398;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u0003"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 5) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 402;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u0004"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 6) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 406;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u0005"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 7) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 410;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u0006"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 8) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 414;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u0007"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 9) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 418;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u0008"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 10) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 422;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u0009"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 426;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u0000"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 11) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 430;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u000A"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 12) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 434;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u000B"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 13) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 438;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u000C"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 14) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 442;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u000D"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 15) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 446;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u000E"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 16) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 450;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u000F"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 17) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 454;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u001C"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 18) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 458;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u001D"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 19) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 462;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u001E"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 20) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 466;
                        SKEYPRESSES  .UpdateValue ( SKEYPRESSES + "\u001F"  ) ; 
                        } 
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 469;
            FSENDDELAY (  __context__  ) ; 
            } 
        
        __context__.SourceCodeLine = 471;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SKEYPRESSES ) >= 5 ))  ) ) 
            { 
            __context__.SourceCodeLine = 473;
            CancelWait ( "WSENDDELAY" ) ; 
            __context__.SourceCodeLine = 474;
            FSENDCOMMAND (  __context__  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SYSTEM_TYPE_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 480;
        SETSYSTEMTYPE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FROM_DEVICE_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 485;
        while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( FROM_DEVICE ) > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 487;
            CancelWait ( "WRECEIVINGDATATIMEOUT" ) ; 
            __context__.SourceCodeLine = 488;
            RECEIVING_DATA  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 489;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( FROM_DEVICE ) > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( FROM_DEVICE , (int)( 1 ) ) != 2) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 491;
                IJUNK = (ushort) ( Functions.GetC( FROM_DEVICE ) ) ; 
                __context__.SourceCodeLine = 489;
                } 
            
            __context__.SourceCodeLine = 493;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( FROM_DEVICE ) > 3 ))  ) ) 
                { 
                __context__.SourceCodeLine = 495;
                ILENGTH = (ushort) ( ((Byte( FROM_DEVICE , (int)( 3 ) ) * 256) + Byte( FROM_DEVICE , (int)( 4 ) )) ) ; 
                __context__.SourceCodeLine = 496;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( FROM_DEVICE ) >= (ILENGTH + 5) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 498;
                    STEMP  .UpdateValue ( Functions.Remove ( (ILENGTH + 5), FROM_DEVICE )  ) ; 
                    __context__.SourceCodeLine = 499;
                    ICHECKSUM = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 500;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)(ILENGTH + 3); 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 502;
                        ICHECKSUM = (ushort) ( (ICHECKSUM + Byte( STEMP , (int)( (A + 1) ) )) ) ; 
                        __context__.SourceCodeLine = 500;
                        } 
                    
                    __context__.SourceCodeLine = 504;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Low( (ushort) ICHECKSUM ) == Byte( STEMP , (int)( Functions.Length( STEMP ) ) )))  ) ) 
                        { 
                        __context__.SourceCodeLine = 506;
                        FPROCESSRESPONSE (  __context__ , STEMP) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 510;
                        STEMP  .UpdateValue ( ""  ) ; 
                        } 
                    
                    } 
                
                } 
            
            __context__.SourceCodeLine = 485;
            } 
        
        __context__.SourceCodeLine = 515;
        FRECEIVINGTIMEOUT (  __context__  ) ; 
        
        
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
        
        __context__.SourceCodeLine = 524;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 525;
        IBACKLIGHT = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 526;
        BACK_LIGHT_ON  .Value = (ushort) ( IBACKLIGHT ) ; 
        __context__.SourceCodeLine = 527;
        ILENGTH = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 528;
        ICHECKSUM = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 529;
        RECEIVING_DATA  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 530;
        Functions.SetArray ( SINITCOMMAND , "" ) ; 
        __context__.SourceCodeLine = 531;
        SADDRESS  .UpdateValue ( Functions.Chr (  (int) ( 1 ) )  ) ; 
        __context__.SourceCodeLine = 532;
        SYSTEMTYPE = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    SKEYPRESSES  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
    SESPCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
    SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 250, this );
    SADDRESS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
    SLINE1TEXT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
    STEMPLINE1TEXT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
    SLINE2TEXT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
    STEMPLINE2TEXT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
    SINITCOMMAND  = new CrestronString[ 5 ];
    for( uint i = 0; i < 5; i++ )
        SINITCOMMAND [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
    
    INITIALIZE = new Crestron.Logos.SplusObjects.DigitalInput( INITIALIZE__DigitalInput__, this );
    m_DigitalInputList.Add( INITIALIZE__DigitalInput__, INITIALIZE );
    
    ENABLE_DEBUGGING = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE_DEBUGGING__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLE_DEBUGGING__DigitalInput__, ENABLE_DEBUGGING );
    
    KEY = new InOutArray<DigitalInput>( 20, this );
    for( uint i = 0; i < 20; i++ )
    {
        KEY[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( KEY__DigitalInput__ + i, KEY__DigitalInput__, this );
        m_DigitalInputList.Add( KEY__DigitalInput__ + i, KEY[i+1] );
    }
    
    BACK_LIGHT_ON = new Crestron.Logos.SplusObjects.DigitalOutput( BACK_LIGHT_ON__DigitalOutput__, this );
    m_DigitalOutputList.Add( BACK_LIGHT_ON__DigitalOutput__, BACK_LIGHT_ON );
    
    RECEIVING_DATA = new Crestron.Logos.SplusObjects.DigitalOutput( RECEIVING_DATA__DigitalOutput__, this );
    m_DigitalOutputList.Add( RECEIVING_DATA__DigitalOutput__, RECEIVING_DATA );
    
    SYSTEM_TYPE = new Crestron.Logos.SplusObjects.AnalogInput( SYSTEM_TYPE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SYSTEM_TYPE__AnalogSerialInput__, SYSTEM_TYPE );
    
    L1_VALUE = new Crestron.Logos.SplusObjects.AnalogOutput( L1_VALUE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( L1_VALUE__AnalogSerialOutput__, L1_VALUE );
    
    L2_VALUE = new Crestron.Logos.SplusObjects.AnalogOutput( L2_VALUE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( L2_VALUE__AnalogSerialOutput__, L2_VALUE );
    
    L3_VALUE = new Crestron.Logos.SplusObjects.AnalogOutput( L3_VALUE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( L3_VALUE__AnalogSerialOutput__, L3_VALUE );
    
    LINE_1_TEXT = new Crestron.Logos.SplusObjects.StringOutput( LINE_1_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( LINE_1_TEXT__AnalogSerialOutput__, LINE_1_TEXT );
    
    LINE_2_TEXT = new Crestron.Logos.SplusObjects.StringOutput( LINE_2_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( LINE_2_TEXT__AnalogSerialOutput__, LINE_2_TEXT );
    
    TO_DEVICE = new Crestron.Logos.SplusObjects.StringOutput( TO_DEVICE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TO_DEVICE__AnalogSerialOutput__, TO_DEVICE );
    
    FROM_DEVICE = new Crestron.Logos.SplusObjects.BufferInput( FROM_DEVICE__AnalogSerialInput__, 1000, this );
    m_StringInputList.Add( FROM_DEVICE__AnalogSerialInput__, FROM_DEVICE );
    
    WRECEIVINGDATATIMEOUT_Callback = new WaitFunction( WRECEIVINGDATATIMEOUT_CallbackFn );
    WSENDDELAY_Callback = new WaitFunction( WSENDDELAY_CallbackFn );
    WINITDELAY_Callback = new WaitFunction( WINITDELAY_CallbackFn );
    
    INITIALIZE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZE_OnPush_0, false ) );
    for( uint i = 0; i < 20; i++ )
        KEY[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( KEY_OnPush_1, false ) );
        
    SYSTEM_TYPE.OnAnalogChange.Add( new InputChangeHandlerWrapper( SYSTEM_TYPE_OnChange_2, false ) );
    FROM_DEVICE.OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_DEVICE_OnChange_3, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_HONEYWELL_4232CBM_PROCESSOR_V1_4 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction WRECEIVINGDATATIMEOUT_Callback;
private WaitFunction WSENDDELAY_Callback;
private WaitFunction WINITDELAY_Callback;


const uint INITIALIZE__DigitalInput__ = 0;
const uint ENABLE_DEBUGGING__DigitalInput__ = 1;
const uint KEY__DigitalInput__ = 2;
const uint SYSTEM_TYPE__AnalogSerialInput__ = 0;
const uint FROM_DEVICE__AnalogSerialInput__ = 1;
const uint BACK_LIGHT_ON__DigitalOutput__ = 0;
const uint RECEIVING_DATA__DigitalOutput__ = 1;
const uint L1_VALUE__AnalogSerialOutput__ = 0;
const uint L2_VALUE__AnalogSerialOutput__ = 1;
const uint L3_VALUE__AnalogSerialOutput__ = 2;
const uint LINE_1_TEXT__AnalogSerialOutput__ = 3;
const uint LINE_2_TEXT__AnalogSerialOutput__ = 4;
const uint TO_DEVICE__AnalogSerialOutput__ = 5;

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
