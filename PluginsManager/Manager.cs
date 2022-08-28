using static System.IO.Directory;

namespace Hangman.PluginsManager;

sealed class Manager
{
	private string? PluginsDir;
	public List<string> GetPluginsFromDirectory(string dir)
	{
		PluginsDir = dir;
		string[] dirs = GetDirectories(dir);
		return dirs.ToList();
	}
	public void LoadAllPlugins(List<string> plugins)
	{
		PluginLoader loader = new();
		foreach (string x in plugins)
		{
			loader.LoadPlugin(Path.GetFileName(x));
		}
	}
}
