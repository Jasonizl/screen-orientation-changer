Imports System.Runtime.InteropServices

Partial Class Form1
    Public Const DMDO_DEFAULT As Integer = 0
    Public Const DMDO_90 As Integer = 1
    Public Const DMDO_180 As Integer = 2
    Public Const DMDO_270 As Integer = 3
    Public Const ENUM_CURRENT_SETTINGS As Integer = -1

    Public screenIndex = 1
    Public Shared displayOrientation = 0

    <StructLayout(LayoutKind.Explicit, CharSet:=CharSet.Ansi)>
    Friend Structure DEVMODE

        Public Const CCHDEVICENAME As Integer = 32
        Public Const CCHFORMNAME As Integer = 32
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=CCHDEVICENAME)>
        <FieldOffset(0)>
        Public dmDeviceName As String
        <FieldOffset(32)>
        Public dmSpecVersion As Int16
        <FieldOffset(34)>
        Public dmDriverVersion As Int16
        <FieldOffset(36)>
        Public dmSize As Int16
        <FieldOffset(38)>
        Public dmDriverExtra As Int16
        <FieldOffset(40)>
        Public dmFields As DM
        <FieldOffset(44)>
        Private dmOrientation As Int16
        <FieldOffset(46)>
        Private dmPaperSize As Int16
        <FieldOffset(48)>
        Private dmPaperLength As Int16
        <FieldOffset(50)>
        Private dmPaperWidth As Int16
        <FieldOffset(52)>
        Private dmScale As Int16
        <FieldOffset(54)>
        Private dmCopies As Int16
        <FieldOffset(56)>
        Private dmDefaultSource As Int16
        <FieldOffset(58)>
        Private dmPrintQuality As Int16
        <FieldOffset(44)>
        Public dmPosition As POINTL
        <FieldOffset(52)>
        Public dmDisplayOrientation As Int32
        <FieldOffset(56)>
        Public dmDisplayFixedOutput As Int32
        <FieldOffset(60)>
        Public dmColor As Short
        <FieldOffset(62)>
        Public dmDuplex As Short
        <FieldOffset(64)>
        Public dmYResolution As Short
        <FieldOffset(66)>
        Public dmTTOption As Short
        <FieldOffset(68)>
        Public dmCollate As Short
        <FieldOffset(72)>
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=CCHFORMNAME)>
        Public dmFormName As String
        <FieldOffset(102)>
        Public dmLogPixels As Int16
        <FieldOffset(104)>
        Public dmBitsPerPel As Int32
        <FieldOffset(108)>
        Public dmPelsWidth As Int32
        <FieldOffset(112)>
        Public dmPelsHeight As Int32
        <FieldOffset(116)>
        Public dmDisplayFlags As Int32
        <FieldOffset(116)>
        Public dmNup As Int32
        <FieldOffset(120)>
        Public dmDisplayFrequency As Int32

    End Structure


    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
    Friend Structure DISPLAY_DEVICE

        <MarshalAs(UnmanagedType.U4)>
        Public cb As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)>
        Public DeviceName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=128)>
        Public DeviceString As String
        <MarshalAs(UnmanagedType.U4)>
        Public StateFlags As DisplayDeviceStateFlags
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=128)>
        Public DeviceID As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=128)>
        Public DeviceKey As String

    End Structure

    Friend Enum DISP_CHANGE

        Successful = 0
        Restart = 1
        Failed = -1
        BadMode = -2
        NotUpdated = -3
        BadFlags = -4
        BadParam = -5
        BadDualView = -6

    End Enum

    <Flags()>
    Friend Enum DisplayDeviceStateFlags

        AttachedToDesktop = &H1
        MultiDriver = &H2
        PrimaryDevice = &H4
        MirroringDriver = &H8
        VGACompatible = &H10
        Removable = &H20
        ModesPruned = &H8000000
        Remote = &H4000000
        Disconnect = &H2000000

    End Enum

    <Flags()>
    Friend Enum DisplaySettingsFlags

        CDS_NONE = 0
        CDS_UPDATEREGISTRY = &H1
        CDS_TEST = &H2
        CDS_FULLSCREEN = &H4
        CDS_GLOBAL = &H8
        CDS_SET_PRIMARY = &H10
        CDS_VIDEOPARAMETERS = &H20
        CDS_ENABLE_UNSAFE_MODES = &H100
        CDS_DISABLE_UNSAFE_MODES = &H200
        CDS_RESET = &H40000000
        CDS_RESET_EX = &H20000000
        CDS_NORESET = &H10000000

    End Enum

    <Flags()>
    Friend Enum DM

        Orientation = &H1
        PaperSize = &H2
        PaperLength = &H4
        PaperWidth = &H8
        Scale = &H10
        Position = &H20
        NUP = &H40
        DisplayOrientation = &H80
        Copies = &H100
        DefaultSource = &H200
        PrintQuality = &H400
        Color = &H800
        Duplex = &H1000
        YResolution = &H2000
        TTOption = &H4000
        Collate = &H8000
        FormName = &H10000
        LogPixels = &H20000
        BitsPerPixel = &H40000
        PelsWidth = &H80000
        PelsHeight = &H100000
        DisplayFlags = &H200000
        DisplayFrequency = &H400000
        ICMMethod = &H800000
        ICMIntent = &H1000000
        MediaType = &H2000000
        DitherType = &H4000000
        PanningWidth = &H8000000
        PanningHeight = &H10000000
        DisplayFixedOutput = &H20000000

    End Enum

    <StructLayout(LayoutKind.Sequential)>
    Friend Structure POINTL

        Private x As Long
        Private y As Long

    End Structure
    <DllImport("user32.dll")>
    Friend Shared Function ChangeDisplaySettingsEx(ByVal _
      lpszDeviceName As String, ByRef lpDevMode As DEVMODE,
      ByVal hwnd As IntPtr, ByVal dwflags As DisplaySettingsFlags,
      ByVal lParam As IntPtr) As DISP_CHANGE

    End Function
    <DllImport("user32.dll")>
    Friend Shared Function EnumDisplayDevices(ByVal lpDevice As _
          String, ByVal iDevNum As UInteger, ByRef lpDisplayDevice _
          As DISPLAY_DEVICE, ByVal dwFlags As UInteger) As Boolean

    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Ansi)>
    Friend Shared Function EnumDisplaySettings(ByVal lpszDeviceName _
          As String, ByVal iModeNum As Integer, ByRef lpDevMode _
          As DEVMODE) As Integer

    End Function

    Public Enum Orientation

        DEGREES_CW_270 = 1
        DEGREES_CW_180 = 2
        DEGREES_CW_90 = 3
        DEGREES_CW_0 = 0

    End Enum

    Public Shared Function Rotate(ByVal uDisplay As UInteger,
         ByVal oOrientation As Orientation, ByVal times As UInteger) As Boolean

        Dim bResult As Boolean = False
        Dim dDevice As DISPLAY_DEVICE = New DISPLAY_DEVICE()
        Dim dmMode As DEVMODE = New DEVMODE()

        dDevice.cb = Marshal.SizeOf(dDevice)

        If Not EnumDisplayDevices(Nothing, uDisplay - 1,
         dDevice, 0) Then Return False

        If 0 <> EnumDisplaySettings _
         (dDevice.DeviceName, ENUM_CURRENT_SETTINGS,
         dmMode) Then


            For i As Integer = 0 To times


                If (dmMode.dmDisplayOrientation + CInt(oOrientation + i)) _
            Mod 2 = 1 Then
                    Dim tmp As Integer = dmMode.dmPelsHeight
                    dmMode.dmPelsHeight = dmMode.dmPelsWidth
                    dmMode.dmPelsWidth = tmp

                End If

                Dim newOrientation = oOrientation + i

                Select Case newOrientation

                    Case Orientation.DEGREES_CW_90
                        dmMode.dmDisplayOrientation = DMDO_270

                    Case Orientation.DEGREES_CW_180
                        dmMode.dmDisplayOrientation = DMDO_180

                    Case Orientation.DEGREES_CW_270
                        dmMode.dmDisplayOrientation = DMDO_90

                    Case Orientation.DEGREES_CW_0
                        dmMode.dmDisplayOrientation = DMDO_DEFAULT

                    Case Else

                End Select

                Dim ret As DISP_CHANGE = ChangeDisplaySettingsEx _
                (dDevice.DeviceName, dmMode, IntPtr.Zero,
                DisplaySettingsFlags.CDS_UPDATEREGISTRY, IntPtr.Zero)
                bResult = ret = 0
            Next
        End If

        Return bResult
    End Function
End Class

Module Module1

    Sub Main()
        Dim clArgs() As String = Environment.GetCommandLineArgs()
        If clArgs.Length < 3 Or clArgs(1) = 0 Then
            Console.WriteLine("Arguments not complete. First argument: screenIndex (0 not allowed). Second argument: orientation times (0,1,2,3).")
            Return
        End If

        Dim screen = clArgs(1)
        Dim times = clArgs(2)

        ' Rotate
        Form1.Rotate(screen, 0, times Mod 4)

        Application.Exit()
    End Sub

End Module
