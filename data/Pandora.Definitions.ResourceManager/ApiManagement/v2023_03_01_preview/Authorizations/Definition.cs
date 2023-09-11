using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.Authorizations;

internal class Definition : ResourceDefinition
{
    public string Name => "Authorizations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AuthorizationListByAuthorizationProviderOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AuthorizationTypeConstant),
        typeof(OAuth2GrantTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AuthorizationContractModel),
        typeof(AuthorizationContractPropertiesModel),
        typeof(AuthorizationErrorModel),
    };
}
