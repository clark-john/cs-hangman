using System.Reflection;
using static System.IO.Directory;
using static System.String;

namespace Hangman.PluginsManager;

sealed class PluginLoader
{
	public void LoadPlugin(string plugin)
	{
		Assembly asm = Assembly.LoadFile(Concat(GetCurrentDirectory(), $"/plugins/{plugin}/{plugin}.dll"));
		Type t = asm.GetTypes()[0];
		object? o = Activator.CreateInstance(t);
		MethodInfo? method = t.GetMethod("CreatePlugin");
		Console.WriteLine(method?.Invoke(o, null));
	}	
}