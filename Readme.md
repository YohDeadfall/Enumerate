# Enumerate
Enumerate is a markup extension and a value converter which allow to bind to `Enum` properties in XAML. It also supports other types for which `TypeConverter.GetStandardValues()` returns a collection of standard values.

## Features

1. Providing values of an `Enum` as is.
2. Providing values of an `Enum` from `DescriptionAttribute`s.

## Usage:

```csharp

public enum ViewModelStatus
{
    [Description("Offen")]
    Open,
    [Description("Geschlossen")]
    Closed,
    [Description("In Arbeit")]
    InProgress
}

public class ViewModel : INotifyPropertyChanged
{
    public ViewModelStatus Status { get; set; }
}

```

```xaml
<ComboBox ItemsSource="{e:Enumerate {x:Type local:ViewModelStatus}, Converter={StaticResource EnumToStringConverter}}"
          SelectedItem="{Binding Status, Converter={StaticResource EnumToStringConverter}}" />
<!-- ItemsSource will contain Offen, Geschlossen and In Arbeit -->
```

## Localization

Specify an `ResourceManager` in the `Description` property and apply this attribute to an `Enum` values.

```csharp
public class LocalizedDescriptionAttribute : DescriptionAttribute
{
    #region Fields

    private string resourceName;

    #endregion

    #region Constructors

    public LocalizedDescriptionAttribute(string resourceName)
    {
        this.resourceName = resourceName;
    }

    #endregion

    #region DescriptionAttribute Members

    public override string Description
    {
        get { return Resources.ResourceManager.GetString(resourceName); }
    }

    #endregion

    #region Properties

    public string ResourceName
    {
        get { return resourceName; }
    }

    #endregion
}
```
