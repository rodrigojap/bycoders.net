import styled from "styled-components";
import { formatCurrency } from "../../utils/currency.utils";

export const CNABGrid = ({ CNABData }) => {
  const Container = styled.div`
    margin-top: 1rem;
    display: grid;
    grid-template-columns: repeat(7, 1fr);
  `;

  interface TotalProps {
    Total: number;
  }
  const TotalContainer = styled.span<TotalProps>`
    color: ${(props) => (props.Total >= 0 ? `green` : `red`)};
  `;

  const ContainerHeader = styled.div``;
  const ContainerBody = styled.div``;

  return (
    <>      
      <div>
        Saldo total é :{" "}
        <TotalContainer Total={CNABData.total}>
          {formatCurrency(CNABData.total)}
        </TotalContainer>
      </div>

      <div>
        <span className="description-operation-list">Lista de Operações:</span>
      </div>

      <Container>
        <ContainerHeader>Valor</ContainerHeader>
        <ContainerHeader>CPF</ContainerHeader>
        <ContainerHeader>Cartão</ContainerHeader>
        <ContainerHeader>Proprietário</ContainerHeader>
        <ContainerHeader>Nome da Loja</ContainerHeader>
        <ContainerHeader>Descrição da Operação</ContainerHeader>
        <ContainerHeader>Data</ContainerHeader>

        {CNABData.operationsList.map((operation) => {
          return (
            <>
              <ContainerBody>{formatCurrency(operation.value)}</ContainerBody>
              <ContainerBody>{operation.cpf}</ContainerBody>
              <ContainerBody>{operation.card}</ContainerBody>
              <ContainerBody>{operation.storeOwner}</ContainerBody>
              <ContainerBody>{operation.storeName}</ContainerBody>
              <ContainerBody>{operation.operationDescription}</ContainerBody>
              <ContainerBody>{operation.operationDate}</ContainerBody>
            </>
          );
        })}
      </Container>
    </>
  );
};
