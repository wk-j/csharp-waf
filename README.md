## WPF Application Framework (WAF)

เป็น​ MVVM Framewok คล้ายกับ Prism แต่เล็กและง่ายกว่า

## ติดตั้ง

- `Install-Package waf`

## สร้าง Solution

#### ประกอบด้วย 2 โปรเจค

- `CodeTronEditor.Applications` เก็บ Model / Logic
- `CodeTronEditor.Presentation` ส่วนแสดงผล (View)

## สร้าง ShellWindow

#### ประกอบด้วยไฟล์ดังนี้

- `CodeTronEditor.Applications/Views/IShellView.cs`
- `CodeTronEditor.Applications/Controllers/IApplicationController.cs`
- `CodeTronEditor.Applications/Controllers/ApplicationController.cs`
- `CodeTronEditor.Presentation/Views/ShellWindow.xaml`
- `CodeTronEditor.Presentation/Views/ShellWindow.xaml.cs`
- `CodeTronEditor.Presentation/App.xaml`
- `CodeTronEditor.Presentation/App.xaml.cs`

#### แก้ไขไฟล์ `App.xmal.cs`

```csharp
protected override void OnStartup(StartupEventArgs e) {
   base.OnStartup(e);
   catalog = new AggregateCatalog();
   catalog.Catalogs.Add(new AssemblyCatalog(typeof(ViewModel).Assembly));
   catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
   catalog.Catalogs.Add(new AssemblyCatalog(typeof(IApplicationController).

   container = new CompositionContainer(catalog, CompositionOptions.DisableSilentRejection);
   CompositionBatch batch = new CompositionBatch();
   container.Compose(batch);

   controller = container.GetExportedValue<IApplicationController>();
   controller.Initialize();
   controller.Run();
}
```

`AggregateCatalog` `CompositionContainer` และ `CompositionBatch` จะช่วย Handle ViewModel และ Controller ภายใน Application

## Link

- http://codetron.net/getting-started-with-the-wpf-application-framework-waf