namespace JandyInterface;
        // class declarations
         class Jandy;
         class JandySessionList;
         class JandyGetHome;
         class JandyGetOneTouch;
         class JandyGetDevices;
     class Jandy 
    {
        // class delegates
        delegate FUNCTION delegateGetSessionInfo ( INTEGER iIndex , SIMPLSHARPSTRING sSerialNumberDisplay , SIMPLSHARPSTRING sLabel , SIMPLSHARPSTRING sOneTouch );
        delegate FUNCTION delegateGetOneTouchInfo ( INTEGER iIndex , SIMPLSHARPSTRING sStatus , SIMPLSHARPSTRING sState , SIMPLSHARPSTRING sLabel );
        delegate FUNCTION delegateGetDevicesScreenInfo ( INTEGER iIndex , SIMPLSHARPSTRING sState , SIMPLSHARPSTRING sLabel , SIMPLSHARPSTRING sIcon , SIMPLSHARPSTRING sType , SIMPLSHARPSTRING sSubtype );
        delegate FUNCTION delegateEndSession ( );
        delegate FUNCTION delegateGetHomeInfo ( SIMPLSHARPSTRING sString1 , SIMPLSHARPSTRING sString2 , SIMPLSHARPSTRING sString3 , SIMPLSHARPSTRING sString4 , SIMPLSHARPSTRING sString5 , SIMPLSHARPSTRING sString6 , SIMPLSHARPSTRING sString7 , SIMPLSHARPSTRING sString8 );
        delegate FUNCTION delegateAuxLightNames ( INTEGER iIndex , SIMPLSHARPSTRING sMessage );
        delegate FUNCTION delegateMessage ( SIMPLSHARPSTRING sMessage );
        delegate FUNCTION delegateWaitMessage ( SIMPLSHARPSTRING sMessage );
        delegate FUNCTION delegateLocation ( SIMPLSHARPSTRING sLocation );
        delegate FUNCTION delegateNumberDevices ( INTEGER iIndex );
        delegate FUNCTION delegateNoConnection ( INTEGER iIndex );

        // class events

        // class functions
        FUNCTION Set_Debug ( SIGNED_INTEGER iValue );
        FUNCTION Aux_Selected ( SIGNED_INTEGER iIndex );
        FUNCTION Set_Aux ( SIGNED_INTEGER iIndex );
        FUNCTION Select_Color ( SIGNED_INTEGER iIndex );
        FUNCTION Set_Dimmer ( SIGNED_INTEGER iIndex );
        FUNCTION Set_SJVA ( SIGNED_INTEGER iIndex );
        FUNCTION Get_Home ();
        FUNCTION Set_Pool_Pump ();
        FUNCTION Set_Pool_Heater ();
        FUNCTION Set_Spa_Pump ();
        FUNCTION Set_Spa_Heater ();
        FUNCTION Set_Solar_Heater ();
        FUNCTION Set_Temp_1 ( SIGNED_INTEGER iValue );
        FUNCTION Set_Temp_2 ( SIGNED_INTEGER iValue );
        FUNCTION Set_SWC_Boost ();
        FUNCTION Set_SWC_Low ();
        FUNCTION Get_OneTouch ();
        FUNCTION Set_OneTouch ( SIGNED_LONG_INTEGER number );
        FUNCTION Get_Devices ();
        FUNCTION Select_Device ( SIGNED_LONG_INTEGER iIndex );
        FUNCTION Get_Session ( STRING sEmailAddress , STRING sPassword );
        FUNCTION Kill_Session ();
        FUNCTION Home_Screen_Info ( STRING request );
        FUNCTION OneTouch_Info ( STRING request );
        FUNCTION Devices_Screen_Info ( STRING request );
        STRING_FUNCTION parse ( STRING sSourceString , STRING sKey );
        FUNCTION getDevicesScreenInfo ( STRING sSourceString , SIGNED_LONG_INTEGER iIndex );
        FUNCTION Select_Aux_Lights ( SIGNED_LONG_INTEGER iIndex );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        DelegateProperty delegateGetSessionInfo SendGetSessionInfo;
        DelegateProperty delegateGetOneTouchInfo SendGetOneTouchInfo;
        DelegateProperty delegateGetDevicesScreenInfo SendGetDevicesScreenInfo;
        DelegateProperty delegateEndSession SendEndSession;
        DelegateProperty delegateGetHomeInfo SendGetHomeInfo1;
        DelegateProperty delegateGetHomeInfo SendGetHomeInfo2;
        DelegateProperty delegateGetHomeInfo SendGetHomeInfo3;
        DelegateProperty delegateAuxLightNames SendAuxLightNames;
        DelegateProperty delegateMessage SendMessage;
        DelegateProperty delegateWaitMessage SendWaitMessage;
        DelegateProperty delegateLocation SendLocation;
        DelegateProperty delegateNumberDevices SendNumberDevices;
        DelegateProperty delegateNoConnection SendNoConnection;
    };

     class JandySessionList 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class JandyGetHome 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING message[];
    };

     class JandyGetOneTouch 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING message[];
    };

     class JandyGetDevices 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING message[];
    };

