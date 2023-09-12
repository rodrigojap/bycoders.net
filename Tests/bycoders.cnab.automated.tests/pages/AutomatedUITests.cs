
namespace bycoders.cnab.automated.tests.pages
{
    public class AutomatedUITests 
    {
        [Theory]
        [InlineData(CNABPage.Browsers.CHROME)]
        [InlineData(CNABPage.Browsers.FIREFOX)]
        public void When_ClickSubmitButtonWithouAttachElement_ShouldDisplayError(CNABPage.Browsers Browser)
        {
            var expeted_error_message = "Houve um erro ao realizar o upload";
            var p = new CNABPage(Browser);

            p.LoadPage();
            p.UploadSubmitButtonClick();

            Assert.Equal(expeted_error_message, p.GetMessageText("display-message"));
        }

        [Theory]
        [InlineData(CNABPage.Browsers.CHROME)]
        [InlineData(CNABPage.Browsers.FIREFOX)]
        public void When_UploadFile_ShouldDisplaySucessMessage(CNABPage.Browsers Browser)
        {
            var page = new CNABPage(Browser);
            var expected_text = "Arquivo enviado com sucesso!";

            page.LoadPage();
            page.AttachFileButtonClick();

            Thread.Sleep(1000);

            page.UploadSubmitButtonClick();

            Assert.Equal(expected_text, page.GetMessageText("display-message"));
        }

        [Theory]
        [InlineData(CNABPage.Browsers.CHROME)]
        [InlineData(CNABPage.Browsers.FIREFOX)]
        public void When_UploadFile_ShouldNavigateIntoDetailsPage(CNABPage.Browsers Browser)
        {
            var expected_operation_description = "Lista de Operações:";
            var page = new CNABPage(Browser);

            page.LoadPage();
            page.AttachFileButtonClick();

            Thread.Sleep(1000);

            page.UploadSubmitButtonClick();

            Thread.Sleep(1000);

            page.FirstUnorderedElementClick();

            Assert.Equal(expected_operation_description, page.GetMessageText("description-operation-list"));
        }
    }
}
