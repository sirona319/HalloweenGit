/// <summary>
/// レイヤー名を定数で管理するクラス
/// </summary>
public static class LayerName
{
	public const int Default = 0;
	public const int TransparentFX = 1;
	public const int IgnoreRaycast = 2;
	public const int Enemy = 3;
	public const int Water = 4;
	public const int UI = 5;
	public const int Player = 6;
	public const int ExitErea = 8;
	public const int EnemyBoss = 10;
	public const int Knife = 12;
	public const int SceneObject = 15;
	public const int Ground = 16;
	public const int BlockReflect = 23;
	public const int NoPost = 30;
	public const int post = 31;
	public const int DefaultMask = 1;
	public const int TransparentFXMask = 2;
	public const int IgnoreRaycastMask = 4;
	public const int EnemyMask = 8;
	public const int WaterMask = 16;
	public const int UIMask = 32;
	public const int PlayerMask = 64;
	public const int ExitEreaMask = 256;
	public const int EnemyBossMask = 1024;
	public const int KnifeMask = 4096;
	public const int SceneObjectMask = 32768;
	public const int GroundMask = 65536;
	public const int BlockReflectMask = 8388608;
	public const int NoPostMask = 1073741824;
	public const int postMask = -2147483648;
}
