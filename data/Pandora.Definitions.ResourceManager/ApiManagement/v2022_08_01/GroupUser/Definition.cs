using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.GroupUser;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupUser";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckEntityExistsOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new ListOperation(),
    };
}
