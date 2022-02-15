namespace ASimpleRPG;
public interface ISaveManager
{
	public string SaveFileLocation { get; set; }
	dynamic Load();
	void Save(dynamic inheritedClass);
	// TODO: #7 Can work with generics
}