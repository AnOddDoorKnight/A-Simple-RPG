namespace ASimpleRPG;
public interface ISaveManager
{
	public string SaveFileLocation { get; }
	T Load<T>();
	void Save<T>(T inheritedClass);
}