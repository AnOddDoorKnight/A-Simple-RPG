namespace ASimpleRPG;


public interface ISaveManager
{
	public string SaveFileLocation { get; }
	T Load<T>();
	void Save<T>(T inheritedClass);
}
public interface ICombat
{
	int BaseInitiative { get; }
	public int NewInitiative => StoredIntiative = BaseInitiative + new System.Random().Next(20); 
	public int StoredIntiative { get; set; }
}