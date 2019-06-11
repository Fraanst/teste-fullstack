using cv.Domain;
using cv.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class DomainValidationProvider : IDomainValidationProvider
    {
        private readonly IList<DomainValidation> _validations = new List<DomainValidation>();

        /// <summary>
        /// Indica se há erros de validação de domínio.
        /// </summary>
        /// <returns></returns>
        public bool HasNotifications()
        {
            return _validations.Any();
        }

        /// <summary>
        /// Adiciona um erro de validação de domínio.
        /// </summary>
        /// <param name="validation">Dados da validação de domínio.</param>
        public void AddValidationError(DomainValidation validation)
        {
            _validations.Add(validation);
        }

        /// <summary>
        /// Adiciona uma lista de erros de validação de domínio.
        /// </summary>
        /// <param name="validations">Lista de validação de domínio.</param>
        public void AddValidationError(IEnumerable<DomainValidation> validations)
        {
            foreach (var validation in validations)
            {
                AddValidationError(validation);
            }
        }

        /// <summary>
        /// Adiciona um erro de validação de domínio.
        /// </summary>
        /// <param name="message">Mensagem da validação.</param>
        /// <param name="field">Nome da propriedade relacionada à validação.</param>
        public void AddValidationError(string message, string field)
        {
            AddValidationError(new DomainValidation(message, field));
        }

        /// <summary>
        /// Adiciona erros de validação de domínio de uma exception.
        /// </summary>
        /// <param name="message">Mensagem da validação.</param>
        /// <param name="field">Nome da propriedade relacionada à validação.</param>
        public void AddValidationError(Exception ex, string field)
        {
            while (ex != null)
            {
                AddValidationError(new DomainValidation(ex.Message, field));
                ex = ex.InnerException;
            }
        }

        /// <summary>
        /// Retorno a lista de erros de validação.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DomainValidation> Notify()
        {
            return _validations;
        }


        /// <summary>
        /// Retorno a lista de erros de validação.
        /// </summary>
        /// <returns></returns>
        public void Clear()
        {
            _validations.Clear();
        }
    }
}
