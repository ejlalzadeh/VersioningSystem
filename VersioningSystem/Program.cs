using VersioningSystem.Model;


VM vm = new VM("10.5.4");

Console.WriteLine(vm.Minor().Patch().Patch().Patch().Release());

Console.WriteLine(vm.Rollback().Rollback().Release());

Console.ReadKey();