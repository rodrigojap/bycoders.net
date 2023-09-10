import { useRouter } from "next/router";
import { styled } from "styled-components";

export const DisplayStores = ({ stores }) => {
  const { push } = useRouter();

  const ListItem = styled.li`
    cursor: pointer;
    &:hover,
    &:focus {
      color: blue;
    }
  `;

  return (
    <div style={{ marginTop: "2.5rem" }}>
      <span>
        Lista de empresas disponíves para visualização. Clique para ver os
        detalhes.
      </span>

      {stores.length > 0 ? (
        <ul>
          {stores.map((item) => (
            <ListItem
              key={item}
              onClick={() => push(`/details?storeName=${item}`)}
            >
              {item}
            </ListItem>
          ))}
        </ul>
      ) : (
        <div>
          Nenhuma operação registrada no momento... tente fazer o upload do CNAB
        </div>
      )}
    </div>
  );
};
