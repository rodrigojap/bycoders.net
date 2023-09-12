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
        <div className="store-list-container">
          <ul className="unordered-store-list-items">
            {stores.map((item) => (
              <ListItem
                className={`store-list-item`}  
                key={item}
                onClick={() => push(`/details?storeName=${item}`)}
              >
                {item}
              </ListItem>
            ))}
          </ul>
        </div>
      ) : (
        <div>
          Nenhuma operação registrada no momento... tente fazer o upload do CNAB
        </div>
      )}
    </div>
  );
};
