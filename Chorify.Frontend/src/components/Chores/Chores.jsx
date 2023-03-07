// import { useState, useEffect } from "react";
// import axios from "axios";
// import "./chores.css";

// const Chores = () => {
//   const [items, setItems] = useState([]);
//   const [expandedItems, setExpandedItems] = useState({});

//   const handleExpandClick = (itemId) => {
//     setExpandedItems((prevExpandedItems) => ({
//       ...prevExpandedItems,
//       [itemId]: !prevExpandedItems[itemId],
//     }));
//   };

//   useEffect(() => {
//     const fetchItems = async () => {
//       try {
//         const { data } = await axios.get(
//           "http://localhost:5160/api/Chore/all",
//           { withCredentials: true }
//         );
//         setItems(data.data);
//         console.log(data.data);
//       } catch (error) {
//         console.error(error);
//       }
//     };

//     fetchItems();
//   }, []);

//   const getColumnCount = () => {
//     const itemCount = items.length;
//     if (itemCount <= 5) {
//       return 1;
//     } else {
//       return Math.ceil(itemCount / 5);
//     }
//   };

//   return (
//     <div className="mainContainer">
//       <div className="choresContainer" style={{ columnCount: getColumnCount() }}>
//         {items.map((item) => (
//           <div
//             className={`choreItem ${expandedItems[item.id] ? "expanded" : ""} ${item.color}`}
//             key={item.id}
//           >
//             <div className="choreItemHeader">
//               <div className="choreItemName">{item.name}</div>
//               <button
//                 className="expandButton"
//                 onClick={() => handleExpandClick(item.id)}
//               >
//                 {expandedItems[item.id] ? "-" : "+"}
//               </button>
//             </div>
//             {expandedItems[item.id] && (
//               <div className="choreItemDetails">
//                 <div className="choreItemDescription">{item.description}</div>
//               </div>
//             )}
//           </div>
//         ))}
//       </div>
//     </div>
//   );
// };

// export default Chores;

import { useState, useEffect, useRef } from "react";
import axios from "axios";
import "./chores.css";

const Chores = () => {
  const [items, setItems] = useState([]);
  const [expandedItems, setExpandedItems] = useState({});
  const columnsRef = useRef([]);

  const handleExpandClick = (itemId) => {
    setExpandedItems((prevExpandedItems) => ({
      ...prevExpandedItems,
      [itemId]: !prevExpandedItems[itemId],
    }));
  };

  useEffect(() => {
    const fetchItems = async () => {
      try {
        const { data } = await axios.get(
          "http://localhost:5160/api/Chore/all",
          { withCredentials: true }
        );
        setItems(data.data);
        console.log(data.data);
      } catch (error) {
        console.error(error);
      }
    };

    fetchItems();
  }, []);

  useEffect(() => {
    const calculateColumnHeights = () => {
      const columnHeights = columnsRef.current.map(
        (column) => column.offsetHeight
      );
      const maxColumnHeight = Math.max(...columnHeights);
      columnsRef.current.forEach((column) => {
        column.style.height = `${maxColumnHeight}px`;
      });
    };
    calculateColumnHeights();
  }, [items]);

  return (
    <div className="mainContainer">
    <button className="btnAdd">
        Add chore
    </button>
      <div className="choresContainer">
        {[0, 1, 2, 3].map((i) => (
          <div
            className="column"
            key={i}
            ref={(el) => (columnsRef.current[i] = el)}
          >
            {items
              .slice(i * 9, i * 9 + 9)
              .map((item) => (
                <div
                  className={`choreItem ${
                    expandedItems[item.id] ? "expanded" : ""
                  } ${item.color}`}
                  key={item.id}
                >
                  <div className="choreItemHeader">
                    <div className="choreItemName">{item.name}</div>
                    <button
                      className="expandButton"
                      onClick={() => handleExpandClick(item.id)}
                    >
                      {expandedItems[item.id] ? "-" : "+"}
                    </button>
                  </div>
                  {expandedItems[item.id] && (
                    <div className="choreItemDetails">
                      <div className="choreItemDescription">
                        {item.description}
                      </div>
                    </div>
                  )}
                </div>
              ))}
          </div>
        ))}
      </div>
    </div>
  );
};

export default Chores;