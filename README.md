


# WPFLibrary
[![NuGet](https://img.shields.io/nuget/v/HMTools.WPFLibrary.svg)](https://www.nuget.org/packages/HMTools.WPFLibrary)

## About
WPF Library for common use scenarios.

## Features
- Behaviors (Treeview || Drag & Drop)
- Commands (Relay)
- Custom Attached Properties (Draggable)
- Enum Binding (Source || Description)
- Freezables (Binding Proxy)
- Validations
- Value Converters
- Styles

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

### Styles
#### Import - App.xaml
	<Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/WPFLibrary;component/Styles/StylesDictionary.xaml" />
                <ResourceDictionary Source="pack://application:,,,/WPFLibrary;component/ValueConverters/ConvertersDictionary.xaml" />
            </ResourceDictionary.MergedDictionaries>
            <Style TargetType="{x:Type TextBox}" BasedOn="{StaticResource TextBox_Base}"/>
            <Style TargetType="{x:Type DataGrid}" BasedOn="{StaticResource DataGrid_Base}"/>
        </ResourceDictionary>
    </Application.Resources>

#### Usage
	<Button Style="{StaticResource Button_ImageButton}"/>

## UML Diagrams
### Behaviors
![BehaviorsUML](https://user-images.githubusercontent.com/42064794/107528961-129ce900-6bc3-11eb-9b94-f73322815d1d.png)
### Commands
![CommandsUML](https://user-images.githubusercontent.com/42064794/107528962-13357f80-6bc3-11eb-8562-895341570395.png)
### Custom Attached Properties
![CustomAttachedPropertiesUML](https://user-images.githubusercontent.com/42064794/107528964-13357f80-6bc3-11eb-9205-f9382902b75a.png)
### Enum Binding
![EnumBindingUML](https://user-images.githubusercontent.com/42064794/107528965-13ce1600-6bc3-11eb-8030-30f9f8245110.png)
### Freezables
![FreezablesUML](https://user-images.githubusercontent.com/42064794/107528968-13ce1600-6bc3-11eb-85a2-482fa1787b35.png)
### Validations
![ValidationsUML](https://user-images.githubusercontent.com/42064794/107528969-1466ac80-6bc3-11eb-8bc5-c5deb5aeb95a.png)
### Value Converters
![ValueConvertersUML](https://user-images.githubusercontent.com/42064794/107528958-12045280-6bc3-11eb-975b-90edd7a91ffe.png)
