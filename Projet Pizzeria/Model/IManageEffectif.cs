
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IManageEffectif {

    /// <summary>
    /// @param c 
    /// @return
    /// </summary>
    public long AddClient(Client c);

    /// <summary>
    /// @param noClient
    /// </summary>
    public void EditClient(long noClient );

    /// <summary>
    /// @param noClient
    /// </summary>
    public void DelClient(long noClient);

}