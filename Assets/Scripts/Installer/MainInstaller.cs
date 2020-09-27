using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.BindInterfacesTo<InputProvider>().AsCached();

		Container.Bind<CellInitializer>().AsCached();
		Container.Bind<FloatingObjectCreator>().AsCached();
		Container.Bind<FloatingObjectCreatePointer>().AsCached();
		Container.Bind<CellChunkContainer>().AsCached();

		Container.Bind<FloatingObjectGenerator>().AsCached();
	}
}