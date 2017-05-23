# tcoreUWP

##AutoMapper

AutoMapper is a simple solution for mapping objects, lists and arrays...

```
using TCore.UniversalApp.Mappers;

var target = new List<BaseModelType>();

firstList.CopyAndShallowPropertiesTo(target);

```

##AutoView
AutoView loads a View for your ViewModel and it calls InitializeViewModel() method on it.

###XAML:
```
xmlns:Common="using:TCore.UniversalApp.Common"

<Common:AutoView IsAnimated="True" IsViewCacheAble="True" ViewModel={Binding MyViewModel}/>
```

###C#: (MVVMLight)
```
using TCore.UniversalApp;

private ITCoreViewModel _myViewModel = new SomeViewModel();
public ITCoreViewModel MyViewModel
{
	get { return _myViewModel; }
	set { Set(ref _myViewModel, value);
}
```

### IsAnimated
Means it uses animation when loads a new ViewModel.

###IsViewCacheAble
Means it will cache your views.

##XmlConverter
It serializes and deserializes your object to XML and back...

##SimpleAnimation
This class can help you to trigger animations on your objects.