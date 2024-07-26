
using DevToys.Api;
using System.ComponentModel.Composition;
using System.Text;
using static DevToys.Api.GUI;
using Label = System.Reflection.Emit.Label;

namespace UlidGenerator;

[Export(typeof(IGuiTool))]
[Name("ULIDGenerator")]                                                         // A unique, internal name of the tool.
[ToolDisplayInformation(
    IconFontName = "FluentSystemIcons",                                       // This font is available by default in DevToys
    IconGlyph = '\uE670',                                                     // An icon that represents a pizza
    GroupName = PredefinedCommonToolGroupNames.Generators,                    // The group in which the tool will appear in the side bar.
    ResourceManagerAssemblyIdentifier = nameof(MyResourceAssemblyIdentifier), // The Resource Assembly Identifier to use
    ResourceManagerBaseName = "UlidGenerator.UlidGenerator",                      // The full name (including namespace) of the resource file containing our localized texts
    ShortDisplayTitleResourceName = nameof(UlidGenerator.ShortDisplayTitle),    // The name of the resource to use for the short display title
    LongDisplayTitleResourceName = nameof(UlidGenerator.LongDisplayTitle),
    DescriptionResourceName = nameof(UlidGenerator.Description),
    AccessibleNameResourceName = nameof(UlidGenerator.AccessibleName))]
public class UlidGeneratorGui : IGuiTool
{
    private static readonly SettingDefinition<int> ulidToGenerate
        = new(
            name: $"{nameof(UlidGenerator)}.{nameof(ulidToGenerate)}",
            defaultValue: 1);
    
    public UIToolView View => new(isScrollable: true,
        Grid()
            .ColumnLargeSpacing()
            .RowLargeSpacing()
            .Rows((GridRow.Settings, Auto), (GridRow.Results, new UIGridLength(1, UIGridUnitType.Fraction)))
            .Columns((GridColumn.Stretch, new UIGridLength(1, UIGridUnitType.Fraction)))
            .Cells(
                Cell(
                    GridRow.Settings,
                    GridColumn.Stretch,
                    Stack()
                        .Vertical()
                        .WithChildren(
                            Label().Text("Generate"),
                            Stack()
                                .Horizontal()
                                .WithChildren(
                                    Button()
                                        .AccentAppearance()
                                        .Text("Generate ULID(s)")
                                        .OnClick(OnGenerateButtonClick),
                                    
                                    Label().Style(UILabelStyle.BodyStrong).Text("x"),
                                    
                                    NumberInput()
                                        .HideCommandBar()
                                        .Minimum(1)
                                        .Maximum(1000)
                                        .OnValueChanged(OnNumberOfUlidToGenerateChanged)
                                        .Value(_settingsProvider.GetSetting(ulidToGenerate))
                                    )
                            
                            
                            )
                    
                    ),
                Cell(
                    GridRow.Results,
                    GridColumn.Stretch,
                    _outputText.Title("Generated ULIDs")
                        .ReadOnly()
                    )
                )
        );

    private static readonly SettingDefinition<bool> uppercase
        = new(
            name: $"{nameof(UlidGenerator)}.{nameof(uppercase)}",
            defaultValue: false);
    
    private enum GridColumn
    {
        Stretch
    }

    
    private enum GridRow
    {
        Settings,
        Results
    }
    
    private readonly ISettingsProvider _settingsProvider;
    private readonly IUIMultiLineTextInput _outputText = MultiLineTextInput();
    
    [ImportingConstructor]
    public UlidGeneratorGui(ISettingsProvider settingsProvider)
    {
        _settingsProvider = settingsProvider;

        OnGenerateButtonClick();
    }

    private void OnNumberOfUlidToGenerateChanged(double value)
    {
        _settingsProvider.SetSetting(ulidToGenerate, (int) value);
        OnGenerateButtonClick();
    }
    private void OnGenerateButtonClick()
    {
        var newUlids = new StringBuilder();

        for(int i = 0; i < Math.Max(_settingsProvider.GetSetting(ulidToGenerate), 1); i++)
        {
            string newUlid = Ulid.NewUlid().ToString();
            newUlids.AppendLine(newUlid);
        }
        
        _outputText.Text(newUlids.ToString());
    }
    
    public void OnDataReceived(string dataTypeName, object? parsedData)
    {
        throw new NotImplementedException();
    }
}