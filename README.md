

# WPFLibrary
[![NuGet](https://img.shields.io/nuget/v/HMTools.WPFLibrary.svg)](https://www.nuget.org/packages/HMTools.WPFLibrary)

## About
WPF Library with common use resources.

## Features
- Behaviors (Treeview || Drag & Drop)
- Commands (Relay)
- Custom Attached Properties (Draggable)
- Enum Binding (Source || Description)
- Freezables (Binding Proxy)
- Validations
- Value Converters

## Note
***Please add an issue on this repository, for every bug fix or additional feature that you wish I'll add.</br>
And I'll try to handle it as fast as I can.***

## Getting Started
WPFLibrary is available on NuGet:
```
Install-Package HMTools.WPFLibrary 
```
### Adding Value Converters To Static Resources
#### App.xaml
	xmlns:converters="clr-namespace:WPFLibrary.ValueConverters;assembly=WPFLibrary"
	 <Application.Resources>
        <ResourceDictionary>
            <converters:BoolToVisibilityConverter x:Key="BoolToVisibilityConverter"/>
            <converters:BitmapToBitmapImageConverter x:Key="BitmapToBitmapImageConverter"/>
            <converters:BoolToVisibilityCollapsedConverter x:Key="BoolToVisibilityCollapsedConverter"/>
            <converters:IsLastItemInContainerConverter x:Key="IsLastItemInContainerConverter"/>
            <converters:EnumToStringConverter x:Key="EnumToStringConverter"/>
            <converters:ReverseBoolConverter x:Key="ReverseBoolConverter"/>
            <converters:TwoIntsToBoolConverter x:Key="TwoIntsToBoolConverter"/>
            <converters:MultiValueEqualityConverter x:Key="MultiValueEqualityConverter"/>
        </ResourceDictionary>
    </Application.Resources>
    
## Code Usage Examples
### Behaviors
#### TreeView - Selected Item Binding Behavior
    xmlns:i="http://schemas.microsoft.com/xaml/behaviors"
    xmlns:b="clr-namespace:WPFLibrary.Behaviors;assembly=WPFLibrary"
    <TreeView ItemsSource="{Binding Items}">
	    <i:Interaction.Behaviors>
	        <b:TreeViewSelectionBehavior
             SelectedItem="{Binding selectedTask}" 
             ExpandSelected="True"/>
	    </i:Interaction.Behaviors>
    </TreeView>

#### Drag And Drop Behavior
    xmlns:i="http://schemas.microsoft.com/xaml/behaviors"
    xmlns:b="clr-namespace:WPFLibrary.Behaviors;assembly=WPFLibrary"
    <TreeView ItemsSource="{Binding Items}">
	    <i:Interaction.Behaviors>
	        <b:DraggableTreeViewItemBehavior Effect="Move"
	        AllowControlDropTarget="True" 
	        AllowItemDropTarget="True"
	        VisualizeOnOver="True"
	        DropCommand="{Binding RelativeSource=
		        {RelativeSource AncestorType=TreeView}, 
		        Path=DataContext.TransferItemCommand}"/>
	    </i:Interaction.Behaviors>
    </TreeView>
### Commands
#### Relay Command
	public RelayCommand SelectCommand { get; private set; }
	
	void SomeMethod(){
		//Option1 Pass Method
		SelectCommand = new RelayCommand(Method); //Call Method From Command
		
		//Option2 Expression
		SelectCommand = new RelayCommand(o => {Do Something;});
		
		//Option3 Do Expression Only If Predicate is True
		SelectCommand = new RelayCommand(o => {Do Something;}, o => <Predicate>);
	}

### Custom Attached Properties
#### IsDraggable
	xmlns:cap="clr-namespace:WPFLibrary.CustomAttachedProperties;assembly=WPFLibrary"
	<SomeControl SomeTrueToBlockProperty="{Binding RelativeSource=
		{RelativeSource Mode=FindAncestor,
		AncestorType={x:Type SomeParentControl}},
		Path=(cap:draggableAttachedProperty.IsBlockDragging),
		Mode=OneWayToSource ,UpdateSourceTrigger=PropertyChanged,
		NotifyOnTargetUpdated=True}"/>

### Enum Binding
#### Enum as source
	xmlns:e="clr-namespace:WPFLibrary.EnumBinding;assembly=WPFLibrary"
    xmlns:g="clr-namespace:EnumLocation"
	<ComboBox ItemsSource="{Binding 
		Source={e:EnumBindingSource {x:Type g:SomeEnum}}}"/>

#### Enum with Description
	[TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum SomeEnum
    {
	    [Description("1st Value")]
        val1,
        [Description("2nd Value")]
        val2
    }

### Freezables
#### Binding Proxy - Allow Get DataContext By Key
	xmlns:f="clr-namespace:WPFLibrary.Freezables;assembly=WPFLibrary"
	<UserControl.Resources>
        <f:BindingProxy x:Key="UCProxy" Data="{Binding }"/>
    </UserControl.Resources>
    
	<SomeControl Command="{Binding Source={StaticResource UCProxy},
		Path=Data.SomeCommand}" 
		CommandParameter="{Binding }"/>

## UML Diagrams
### Commands
![](./ReadmeResources/CommandsUML.svg?raw=1)
### Custom Attached Properties
![](./ReadmeResources/CustomAttachedPropertiesUML.svg?raw=1)
### Enum Binding
![](./ReadmeResources/EnumBindingUML.svg?raw=1)
### Freezables
![](./ReadmeResources/FreezablesUML.svg?raw=1)
### Validations
![](./ReadmeResources/ValidationsUML.svg?raw=1)
### Behaviors
![](./ReadmeResources/BehaviorsUML.svg?raw=1)
### Value Converters
![](./ReadmeResources/ValueConvertersUML.svg?raw=1)
