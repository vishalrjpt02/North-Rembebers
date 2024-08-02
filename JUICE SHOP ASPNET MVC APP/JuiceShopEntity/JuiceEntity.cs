/****************************************************************************************
 * @author  : Vishal kumar
 * @file    : JuiceEntity.c#
 * @purpose : to create the entity of the juice center
 * **************************************************************************************/

using System;
namespace JuiceShopEntity
{
    public class JuiceEntity
    {
        public int JuiceId { get; set; }
        public String Flavour { get; set; }
        public double Price { get; set; }
        
        public JuiceEntity() { }
        
    }
}
