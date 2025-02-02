using System;
using System.Collections.Generic;

namespace HORSES.Models;

public partial class Donation
{
    public int Id { get; set; }

    public int? DonationSumm { get; set; }

    public int? HorseId { get; set; }

    public virtual Horse? Horse { get; set; }

    public Donation (int DonationSumm, int HorseId)
    {
        this.DonationSumm = DonationSumm;
        this.HorseId = HorseId;
    }

    public Donation()
    {

    }
}
