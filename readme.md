To create pattern dependeces 


This command create a folder tree based on the './Model'. But not editing nothing in files
```powershell
.\createDependeces.ps1
```

this command create a folder tree but will ignore 'file.cs' file comming from  './Model'

```powershell
.\createDependeces.ps1 --ignore file.cs
```

this command will edit namespace of Domain.Model files
```powershell
.\createDependeces.ps1 --basenamespace namespace.project
```

this command will create dependences by variable in params
```powershell
.\createDependences.ps1 -New Name.of.dependences
```


TODO:
- create a IRepository< T >
- create a iclassrepository : irepository< class > 