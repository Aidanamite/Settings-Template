using UnityEngine;
using System.Collections.Generic;
using HMLLibrary;
using System.Runtime.CompilerServices;

public class SettingsTemplate : Mod
{
    string myNewKey;
    public void Start()
    {
        Log("mod has been loaded!");
    }

    public void Update()
    {
        if (ExtraSettingsAPI_Loaded && MyInput.GetButton(myNewKey))
            Log("Key is pressed");
    }

    public void OnModUnload()
    {
        Log("mod has been unloaded!");
    }

    // ---------------------- All the API related methods and fields are optional -----------------------------------------

    public void ExtraSettingsAPI_Load() // Occurs when the API loads the mod's settings
    {
        myNewKey = ExtraSettingsAPI_GetKeybindName("keybindDisplay");
    }

    public void ExtraSettingsAPI_Unload() // Occurs when the API unloads
    {
        
    }

    public void ExtraSettingsAPI_SettingsOpen() // Occurs when user opens the settings menu
    {

    }

    public void ExtraSettingsAPI_SettingsClose() // Occurs when user closes the settings menu
    {
        
    }

    public void ExtraSettingsAPI_SettingsCreate() // Occurs when API creates the controls for the settings of this mod. This event still occurs but is now obsolete, use the SettingsOpen event instead
    {

    }

    public void ExtraSettingsAPI_ButtonPress(string SettingName) // Occurs when a settings button is clicked. "name" is set the the button's name
    {
        if (SettingName == "buttonDisplay")
            Log("I've been clicked");
    }

    public void ExtraSettingsAPI_ButtonPress(string SettingName, int Index) // Occurs when a multibutton settings' button is clicked. "name" is set the the multibutton's name and "index" is the index of the button clicked
    {
        if (SettingName == "multibuttonDisplay")
            Log(ExtraSettingsAPI_GetButtons(SettingName)[Index] + " was clicked");
    }

    // Occurs when API checks if a "globalcustom" or "worldcustom" access setting should be visible.
    // If true is returned the setting will be visible, if false it will not be visible
    public bool ExtraSettingsAPI_HandleSettingVisible(string SettingName) 
    {
        if (SettingName == "inputDisplay")
            return Random.Range(0, 2) == 0;
        return false;
    }

    // Occurs when a slider setting that is set to the "custom" type is changed.
    // Returned string is shown on the slider's value display.
    // Method can be changed to return any object and the returned object will be converted to a string via "ToString()"
    // "name" is the setting's name and "value" is the slider's real value
    public string ExtraSettingsAPI_HandleSliderText(string name, float value)
    {
        return null;
    }


    // This variable is automatically changed.
    static bool ExtraSettingsAPI_Loaded = false; // This is set to true while the mod's settings are loaded

    /*
     =================================================
     | You can use ONE of these if you want to
     | move ALL the settings api methods to another class.
     | These can be changed to non-static and or public if
     | you want and can use any class in place of
     | "MySettingsClass". Keep in mind, if you're using one
     | of these then all theAPI related methods must be in
     | that class instead of the mod's main class.
     =================================================
    */
    // static MySettingsClass ExtraSettingsAPI_Settings;
    // static MySettingsClass ExtraSettingsAPI_Settings = new MySettingsClass();
    // static Type ExtraSettingsAPI_Settings = typeof(MySettingsClass);


    /*
     =================================================
     | Use the following methods to get/set the values of
     | the settings. These functions will throw Exceptions
     | if either the specified name is wrong or the
     | setting does not exist. These functions will only
     | allow you to get the settings that belong to your
     | mod. This means you don't need to worry about mod
     | conflicts in the settings. You also don't need to
     | put contents for any of these methods, the API will
     | handle that for you.
     =================================================
    */

    /*
     =================================================
     | These methods can be don't have to be static or can
     | have a first parameter of type Mod (or one of its
     | derived types). Note: it cannot be both non-static
     | and have the extra first parameter. You can also
     | change the name of the parameters to anything you
     | want.
     |
     | Because of some issues with how things are
     | handled, it's highly recommended, but not
     | required, to include the MethodImpl attribute
     | on these methods
     =================================================
    */

    // Use to trigger a global settings save, same as the player closing the settings menu.
    // This is only automatically called by "data" settings, other settings types you'll need
    // to call this yourself if you want to edit then save the settings without the user opening
    // and closing the settings.
    // Note: this only triggers the global settings save. World stored settings are still only
    // saved when the world is saved.

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)] // You don't need to have the "System.Runtime.CompilerServices." part if you add "using System.Runtime.CompilerServices" to the top of the file
    public static void ExtraSettingsAPI_SaveSettings() { }

    // Use to get the selected index from a Combobox type setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int ExtraSettingsAPI_GetComboboxSelectedIndex(string SettingName) => -1;

    // Use to get the selected item name from a Combobox type setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string ExtraSettingsAPI_GetComboboxSelectedItem(string SettingName) => "";

    // Use to get the list of items in a Combobox type setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string[] ExtraSettingsAPI_GetComboboxContent(string SettingName) => new string[0];

    // Use to get the current state of a Checkbox type setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool ExtraSettingsAPI_GetCheckboxState(string SettingName) => false;

    // Use to get the current value from a Slider type setting
    // This method returns the value of the slider rounded according to the mod's setting configuration
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float ExtraSettingsAPI_GetSliderValue(string SettingName) => 0;

    // Use to get the current value from a Slider type setting
    // This method returns the non-rounded value of the slider
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float ExtraSettingsAPI_GetSliderRealValue(string SettingName) => 0;

    // Use to get the keybind name for a Keybind type setting
    // The returned name can be used with the MyInput functions to detect keypresses
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string ExtraSettingsAPI_GetKeybindName(string SettingName) => "";

    // Use to get the raw keybind for a Keybind type setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Keybind ExtraSettingsAPI_GetKeybind(string SettingName) => null;

    // Use to get the main key for a Keybind type setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static KeyCode ExtraSettingsAPI_GetKeybindMain(string SettingName) => KeyCode.None; // can also be named: ExtraSettingsAPI_GetKeybind_main

    // Use to get the alternate key for a Keybind type setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static KeyCode ExtraSettingsAPI_GetKeybindAlt(string SettingName) => KeyCode.None; // can also be named: ExtraSettingsAPI_GetKeybind_alt

    // Use to get the input value from a Input type setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string ExtraSettingsAPI_GetInputValue(string SettingName) => "";

    // Use to get the value of an item inside a Data type setting
    // If no item with the specified subname exists it will return an empty string
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string ExtraSettingsAPI_GetDataValue(string SettingName, string subname) => "";

    // Use to get the subnames of all the items inside a Data type setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string[] ExtraSettingsAPI_GetDataNames(string SettingName) => new string[0];

    // Use to get the current button labels of a MultiButton setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string[] ExtraSettingsAPI_GetButtons(string SettingName) => new string[0];

    // Use to get the text label of a setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string ExtraSettingsAPI_GetText(string SettingName) => ""; // can also be named: ExtraSettingsAPI_GetSettingText, ExtraSettingsAPI_GetSettingsText 

    // Use to set the selected index in a Combobox type setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ExtraSettingsAPI_SetComboboxSelectedIndex(string SettingName, int value) { }

    // Use to set the selected item in a Combobox type setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ExtraSettingsAPI_SetComboboxSelectedItem(string SettingName, string value) { }

    // Use to set the items listed in a Combobox type setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ExtraSettingsAPI_SetComboboxContent(string SettingName, string[] value) { }

    // Use to add an item to the items listed in a Combobox type setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ExtraSettingsAPI_AddComboboxContent(string SettingName, string value) { }

    // Use to reset items listed in a Combobox type setting to the list set in the mod json
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ExtraSettingsAPI_ResetComboboxContent(string SettingName) { }

    // Use to set the current state of a Checkbox type setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ExtraSettingsAPI_SetCheckboxState(string SettingName, bool value) { }

    // Use to set the value of a Slider type setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ExtraSettingsAPI_SetSliderValue(string SettingName, float value) { }

    // Use to set the current main keybinding for a Keybind type setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ExtraSettingsAPI_SetKeybindMain(string SettingName, KeyCode value) { } // can also be named: ExtraSettingsAPI_SetKeybind_main

    // Use to set the current alternative keybinding for a Keybind type setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ExtraSettingsAPI_SetKeybindAlt(string SettingName, KeyCode value) { } // can also be named: ExtraSettingsAPI_SetKeybind_alt

    // Use to set the value of a Input type setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ExtraSettingsAPI_SetInputValue(string SettingName, string value) { }

    // Use to set the value of an item inside a Data type setting
    // If no item with the specified subname exists, a new item will be created with the specified value
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ExtraSettingsAPI_SetDataValue(string SettingName, string subname, string value) { }

    // Use to set the values of a Data type setting
    // This completely replaces the contents of the setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ExtraSettingsAPI_SetDataValues(string SettingName, Dictionary<string, string> values) { }

    // Use to set the buttons shown in a MultiButton type setting
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ExtraSettingsAPI_SetButtons(string SettingName, string[] buttons) { }

    // Use to set the text label of a setting
    // This change is not stored in the save data
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ExtraSettingsAPI_SetText(string SettingName, string value) { } // can also be named: ExtraSettingsAPI_SetSettingText, ExtraSettingsAPI_SetSettingsText

    // Use to reset a setting to its default value
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ExtraSettingsAPI_ResetSetting(string SettingName) { }

    // Use to reset all settings to their default values
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ExtraSettingsAPI_ResetAllSettings() { } // can also be named: ExtraSettingsAPI_ResetSettings

    // Use to make the settings api recheck which settings should be visible. Primary use is when using the "globalcustom" or "worldcustom" access modes on settings
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ExtraSettingsAPI_CheckSettingVisibility() { }
}