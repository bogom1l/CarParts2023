namespace CarParts.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDealerService
    {
        public Task<int> GetDealerIdByUserIdAsync(string userId);

        public Task<bool> AgentExistsByUserIdAsync(string userId);
    }
}
