using VersioningSystem.Model;

VM vm = new VM("10.5");

Console.WriteLine(vm.Major().Major().Major().Minor().Release());

Console.WriteLine(vm.Rollback().Release());

Console.ReadKey();