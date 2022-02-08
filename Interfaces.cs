namespace ASimpleRPG;
public interface ISaveManager
{
	dynamic Load();
	void Save(dynamic inheritedClass);
	// TODO: #7 Can work with generics
}