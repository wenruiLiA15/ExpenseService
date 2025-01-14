using System.Reflection.Metadata;
using Expense.Service;
using Expense.Service.Exceptions;
using Expense.Service.Expense;
using Expense.Service.Projects;
using Xunit;

namespace Expense.Service.Test
{
    public class ExpenseServiceTest
    {
        [Fact]
        public void Should_return_internal_expense_type_if_project_is_internal()
        {
            // given
            Project project = new Project(ProjectType.INTERNAL, "internal_project");
            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(expenseType, ExpenseType.INTERNAL_PROJECT_EXPENSE);
        }

        [Fact]
        public void Should_return_expense_type_A_if_project_is_external_and_name_is_project_A()
        {
            // given
            Project project = new Project(ProjectType.EXTERNAL, "Project A");
            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(expenseType, ExpenseType.EXPENSE_TYPE_A);
        }

        [Fact]
        public void Should_return_expense_type_B_if_project_is_external_and_name_is_project_B()
        {
            // given
            Project project = new Project(ProjectType.EXTERNAL, "Project B");
            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(expenseType, ExpenseType.EXPENSE_TYPE_B);
        }

        [Fact]
        public void Should_return_other_expense_type_if_project_is_external_and_has_other_name()
        {
            //given
            Project project = new Project(ProjectType.EXTERNAL, "liwenrui");
            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(expenseType, ExpenseType.OTHER_EXPENSE);
        }

        [Fact]
        public void Should_throw_unexpected_project_exception_if_project_is_invalid()
        {
            //given
            Project project = new Project(ProjectType.UNEXPECTED_PROJECT_TYPE, "liwenrui");
            // when
            // then
            Assert.Throws<UnexpectedProjectTypeException>(() =>
                ExpenseService.GetExpenseCodeByProjectTypeAndName(project));
        }
    }
}