using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Deiarts.Common.Client.Components.Forms;

public abstract partial class DeiSelectorAbstractField<TValue> where TValue : struct
{
    private readonly Dictionary<TValue, ChoiceOption<TValue>> _options = [];
        
        private string _currentTerm = "";
        private MudAutocomplete<TValue?> _autocomplete = default!;
        
        private string GetHelpText(string label) => HelpText ?? $"Digite para pesquisar itens para \"{label}\"";   
        
        [Parameter] public string? HelpText { get; set; }
        
        [Parameter] public string? Label { get; set; }
        [Parameter] public string? Placeholder { get; set; }

        [Parameter] public required TValue? Value { get; set; }
        [Parameter] public required EventCallback<TValue?> ValueChanged { get; set; }
        [Parameter] public required Expression<Func<TValue?>> ValueExpression { get; set; }
        
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public bool ReadOnly { get; set; }
        [Parameter] public bool Clearable { get; set; }

        protected abstract Func<string, Task<ChoiceOption<TValue>[]>> ItemsSearch { get; }
        protected abstract Func<TValue, Task<ChoiceOption<TValue>>> ItemRecover { get; }
        

        private async Task<IEnumerable<TValue?>> SearchAsync(string term, CancellationToken _)
        {
            _currentTerm = term;
            var options = await ItemsSearch(_currentTerm);
            
            foreach (var option in options)
            {
                _options[option.Value] = option;
            }
            
            return options.Select(option => (TValue?)option.Value).ToArray();
        }

        private string? ToStringFunc(TValue? value)
        {
            return value is null ? null : _options.GetValueOrDefault(value.Value)?.Name;
        }

        protected override async Task OnParametersSetAsync()
        {
            if (!Value.Equals(default) && !_options.ContainsKey(Value.Value))
            {
                try
                {
                    var option = await ItemRecover(Value.Value);
                    _options[option.Value] = option;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return;
                }
            }
            
            await base.OnParametersSetAsync();
        }

        private async Task ClearAsync()
        {
            Value = null;
            await ValueChanged.InvokeAsync(Value);
        }
    }