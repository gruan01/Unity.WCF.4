// Decompiled with JetBrains decompiler
// Type: Unity.Wcf.UnityServiceHost
// Assembly: Unity.Wcf, Version=3.5.1404.0, Culture=neutral, PublicKeyToken=2ec651f14ef84543
// MVID: B09534E1-9CF7-44BC-9C32-DE0911F04D9C
// Assembly location: D:\NET\XXY.Mail\XXY.Mail\packages\Unity3.Wcf.3.5.1404.0\lib\net45\Unity.Wcf.dll

using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Unity.Wcf
{
  public sealed class UnityServiceHost : ServiceHost
  {
    public UnityServiceHost(IUnityContainer container, Type serviceType, params Uri[] baseAddresses)
      : base(serviceType, baseAddresses)
    {
      if (container == null)
        throw new ArgumentNullException("container");
      this.ApplyServiceBehaviors(container);
      this.ApplyContractBehaviors(container);
      foreach (ContractDescription contractDescription in (IEnumerable<ContractDescription>) this.ImplementedContracts.Values)
      {
        UnityContractBehavior contractBehavior = new UnityContractBehavior((IInstanceProvider) new UnityInstanceProvider(container, contractDescription.ContractType));
        contractDescription.Behaviors.Add((IContractBehavior) contractBehavior);
      }
    }

    private void ApplyContractBehaviors(IUnityContainer container)
    {
      foreach (IContractBehavior contractBehavior in UnityContainerExtensions.ResolveAll<IContractBehavior>(container))
      {
        foreach (ContractDescription contractDescription in (IEnumerable<ContractDescription>) this.ImplementedContracts.Values)
          contractDescription.Behaviors.Add(contractBehavior);
      }
    }

    private void ApplyServiceBehaviors(IUnityContainer container)
    {
      foreach (IServiceBehavior serviceBehavior in UnityContainerExtensions.ResolveAll<IServiceBehavior>(container))
        this.Description.Behaviors.Add(serviceBehavior);
    }
  }
}
