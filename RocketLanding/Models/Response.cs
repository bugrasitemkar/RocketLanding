using System.ComponentModel.DataAnnotations;

namespace RocketLanding.Models
{
    /// <summary>
    ///     Possible responses
    /// </summary>
    public enum Response
    {
        [Display(Name = "ok for landing")]
        OK = 0,
        [Display(Name = "clash")]
        Clash = 1,
        [Display(Name = "out of platform")]
        OutOfPlatform
    }
}
