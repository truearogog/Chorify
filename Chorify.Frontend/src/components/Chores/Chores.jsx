import { useState, useEffect } from "react";
import axios from "axios";

const Chores = () => {
  const [items, setItems] = useState([]);

  useEffect(() => {
    const fetchItems = async () => {
      try {
        const { data } = await axios.get("http://localhost:5160/api/Chore/all");
        setItems(data);
        console.log(data);
      } catch (error) {
        console.error(error);
      }
    };

    fetchItems();
  }, []);

  return (
    <div>
      <h1>Items</h1>
      {/* <ul>
        {items.map((item) => (
          <li key={item.id}>{item.name}</li>
        ))}
      </ul> */}
    </div>
  );
};

export default Chores;
