// Decompiled with JetBrains decompiler
// Type: Unity.Wcf.UnityInstanceProvider
// Assembly: Unity.Wcf, Version=3.5.1404.0, Culture=neutral, PublicKeyToken=2ec651f14ef84543
// MVID: B09534E1-9CF7-44BC-9C32-DE0911F04D9C
// Assembly location: D:\NET\XXY.Mail\XXY.Mail\packages\Unity3.Wcf.3.5.1404.0\lib\net45\Unity.Wcf.dll

using Microsoft.Practices.Unity;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Unity.Wcf
{
  public sealed class UnityInstanceProvider : IInstanceProvider
  {
    private readonly IUnityContainer container;
    private readonly System.Type contractType;

    public UnityInstanceProvider(IUnityContainer container, System.Type contractType)
    {
      if (container == null)
        throw new ArgumentNullException("container");
      if (contractType == (System.Type) null)
        throw new ArgumentNullException("contractType");
      this.container = container;
      this.contractType = contractType;
    }

    public object GetInstance(InstanceContext instanceContext, Message message)
    {
      if (instanceContext == null)
        throw new ArgumentNullException("instanceContext");
      return UnityContainerExtensions.Resolve(instanceContext.Extensions.Find<UnityInstanceContextExtension>().GetChildContainer(this.container), this.contractType, new ResolverOverride[0]);
    }

    public object GetInstance(InstanceContext instanceContext)
    {
      if (instanceContext == null)
        throw new ArgumentNullException("instanceContext");
      return this.GetInstance(instanceContext, (Message) null);
    }

    public void ReleaseInstance(InstanceContext instanceContext, object instance)
    {
      if (instanceContext == null)
        throw new ArgumentNullException("instanceContext");
      instanceContext.Extensions.Find<UnityInstanceContextExtension>().DisposeOfChildContainer();
    }
  }
}
