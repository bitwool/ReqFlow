using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Metadata;
using ReqFlow.Core.Models;
using ReqFlow.UI.ViewModels;

namespace ReqFlow.UI.DataTemplates;

public class NodeTypeTemplateSelector : IDataTemplate
{

    [Content] public IDataTemplate FolderDataTemplate { get; set; }
    public IDataTemplate ApiDefinitionDataTemplate { get; set; }
    public IDataTemplate TestCaseDataTemplate { get; set; }


    public Control Build(object param)
    {
        if (param is CollectionNode node)
        {
            switch (node.NodeType)
            {
                case NodeTypeEnum.Folder:
                    return FolderDataTemplate?.Build(param);
                case NodeTypeEnum.ApiDefinition:
                    return ApiDefinitionDataTemplate?.Build(param);
                case NodeTypeEnum.TestCase:
                    return TestCaseDataTemplate?.Build(param);
                default:
                    return null;
            }
        }

        return null;
    }

    public bool Match(object data)
    {
        return data is CollectionNode;
    }

}