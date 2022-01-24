namespace ASimpleRPG;
public interface ISaveManager
{
	dynamic Load();
	void Save(dynamic inheritedClass);
}